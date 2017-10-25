using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadsideCannon : MonoBehaviour { // using MonoBehaviour to access instantiate method
	[Range(1f,1000f)] public float ejectPower;
	private Rigidbody rigidbody;
	public CannonBall cannonBallPrefab;

	void Start(){
		//cannonBallPrefab = Resources.Load ("Prefab-CannonBall") as CannonBall;
	}

	void OnEnable(){
		BroadsideCannonModel.OnCannonLevelChange += LevelChangeHandler;
	}
	void OnDisable(){
		BroadsideCannonModel.OnCannonLevelChange -= LevelChangeHandler;
	}

	private void LevelChangeHandler(int newLevel)
	{
		//reloadTime = BroadsideCannonModel.CannonReloadSpeed;
		// I change the concept quite a bit so this is well work in progress
	}

	public float CannonThrust{get; set;}

	public void FireCannon(){
		//Debug.Log ("FIRE!");
		CannonBall newBall = Instantiate (cannonBallPrefab, transform.position, transform.rotation);
		newBall.setTimeToArm (30f);
		newBall.setTimeToDetonate (20f);
		rigidbody = newBall.GetComponent<Rigidbody>();
		rigidbody.AddForce(transform.up * ejectPower);
	}
}
