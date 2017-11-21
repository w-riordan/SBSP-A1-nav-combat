using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MakeRadarObject : MonoBehaviour {

    public Image image;

	// Use this for initialization
	void Start () {
        Radar.RegisterRadarObject(this.gameObject, image);
    }

    void OnDestroy()
    {
        Radar.RemoveRadarObject(this.gameObject); 
    }


}
