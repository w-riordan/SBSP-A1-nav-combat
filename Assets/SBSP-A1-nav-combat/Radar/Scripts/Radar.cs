using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Keeps track of the image icon on the radar and which game Object owns it
public class RadarObject
{
    public Image icon { get; set; }
    public GameObject owner { get; set; }
}

public class Radar : MonoBehaviour {

    public Transform playerPos; //position of player
    float mapScale = 2.0f; //scale radar size

    public static List<RadarObject> radObjects = new List<RadarObject>();

    //Registers Object to the radar
    public static void RegisterRadarObject(GameObject o, Image i)
    {
        Image image = Instantiate(i);
        radObjects.Add(new RadarObject() { owner = o, icon = image }); //adds to List
    }

    //It loops through the list looking for the owner existing in the list, when it finds the owner is detroys the icon
    public static void RemoveRadarObject(GameObject o)
    {
        //New list for destroyed objects
        List<RadarObject> newList = new List<RadarObject>();
        for (int i = 0; i < radObjects.Count; i++)
        {
            if (radObjects[i].owner == o)
            {
                Destroy(radObjects[i].icon);
                continue;
            }
             else
                newList.Add(radObjects[i]);
            }
        radObjects.RemoveRange(0, radObjects.Count);
        radObjects.AddRange(newList);
    }


    void DrawRadarDots()
    {
        //loops through the list and for each Object it gets the owners transform position and determins the difference between it's
        //position and the players position, does calculations on the angle and distance and position on a circle using polar equations.
        foreach (RadarObject ro in radObjects)
        {
            Vector3 radarPos = (ro.owner.transform.position - playerPos.position);
            float distToObject = Vector3.Distance(playerPos.position, ro.owner.transform.position) * mapScale;
            float deltay = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - playerPos.eulerAngles.y;
            radarPos.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
            radarPos.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);

            //grabs icon of players objects and make it a child of panel and set it's postion based on radarPos.x and radarPos.z
            ro.icon.transform.SetParent(this.transform);
            ro.icon.transform.position = new Vector3(radarPos.x, radarPos.z, 0) + this.transform.position;
        }
    }
    
        //Update is called once per frame
        void Update ()
        {
            DrawRadarDots();
        }
}
