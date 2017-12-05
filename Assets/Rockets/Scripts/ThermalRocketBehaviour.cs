using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermalRocketBehaviour : MonoBehaviour {

	private float distance;
    private GameObject EnemyKamikazeShip;
	// Use this for initialization
	void Awake () {
        EnemyKamikazeShip = GameObject.FindGameObjectWithTag("Enemy Kamikaze Ship");
    }



    void OnCollisionEnter(Collision collision)
    {
		Debug.Log ("In collider");
        if (collision.gameObject.tag == "Enemy Kamikaze Ship")
        {
			destroyOnImpact (collision.gameObject);
        }
    }

	void destroyOnImpact(GameObject target) { 
		Destroy (target);
		Destroy (this.gameObject);
	}

    // Update is called once per frame
    void Update () {

		if (EnemyKamikazeShip != null) {
			distance = Vector3.Distance (EnemyKamikazeShip.transform.position, transform.position);
		
			if (distance < 500) {
				var speed = 60;
				var d = EnemyKamikazeShip.transform.position - transform.position;
				d.Normalize ();
				var moveRocket = speed * Time.deltaTime;
				transform.position = transform.position + (d * moveRocket);
				transform.LookAt (EnemyKamikazeShip.transform);
			}
		}
    }
}
