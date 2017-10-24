using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadsideCannon : MonoBehaviour {
	[Range(1f,1000f)] public float thrust;
	private Rigidbody rigidbody;
	public CannonBall cannonBall;
	public GameObject spawnGO;
	private float reloadTime = 5f;
	private float lastFireTime = 0f;

	//Properties
	public float ReloadTime
	{
		get
		{
			return reloadTime;
		}
		set
		{
			reloadTime = value;
		}
	}

	public float CannonThrust{get; set;}

	public void FireCannon(){
		if (timeFromLastFire () > reloadTime) {
			Debug.Log ("FIRE!");
			CannonBall newBall = Instantiate (cannonBall, spawnGO.transform.position, spawnGO.transform.rotation);
			newBall.setTimeToArm (30f);
			newBall.setTimeToDetonate (20f);
			rigidbody = newBall.GetComponent<Rigidbody>();
			rigidbody.AddForce(spawnGO.transform.forward * thrust);
			lastFireTime = Time.time;
		} else {
			Debug.Log ("reloading");
		}
	}

	private float timeFromLastFire(){
		float timeFromLastFire = Time.time - lastFireTime;
		return timeFromLastFire;
	}
}
