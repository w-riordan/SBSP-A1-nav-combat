using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadsideCannon : MonoBehaviour { // using MonoBehaviour to access instantiate method
	[Range(1f,1000f)] public float ejectPower;
	private Rigidbody rigidbody;
	public CannonBall cannonBallPrefab;
	public BroadsideCannonsModel2 broadsideCannonModel;

	void Start(){
		//cannonBallPrefab = Resources.Load ("Prefab-CannonBall") as CannonBall;

	}

	void OnEnable(){
		broadsideCannonModel.OnCannonLevelChange += LevelChangeHandler;
		broadsideCannonModel.OnCannonThrustLevelChange += ForceChangeHandler;
		broadsideCannonModel.OnCannonBallDistanceChange += DistanceChangeHandler;
	}
	void OnDisable(){
		broadsideCannonModel.OnCannonLevelChange -= LevelChangeHandler;
		broadsideCannonModel.OnCannonThrustLevelChange -= ForceChangeHandler;
		broadsideCannonModel.OnCannonBallDistanceChange -= DistanceChangeHandler;
	}

	private void LevelChangeHandler(int newLevel)
	{
		//Debug.Log (newLevel);
	}

	private void ForceChangeHandler(float newForce)
	{
		//Debug.Log (newForce);
		ejectPower = newForce;
	}

	private void DistanceChangeHandler(float newDistance)
	{
		//Debug.Log (newForce);
		timeToDetonate = newDistance;
	}


	public float CannonThrust{get; set;}

	private float timeToDetonate = 10f;

	public void FireCannon(){
		//Debug.Log ("FIRE!");
		CannonBall newBall = Instantiate (cannonBallPrefab, transform.position, transform.rotation);
		newBall.setTimeToArm (30f);
		newBall.setTimeToDetonate (timeToDetonate);
		rigidbody = newBall.GetComponent<Rigidbody>();
		rigidbody.AddForce(transform.up * ejectPower);
	}
}
