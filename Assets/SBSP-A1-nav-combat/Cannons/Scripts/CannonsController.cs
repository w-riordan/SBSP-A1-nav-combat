using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonsController : MonoBehaviour {

	private float lastFireTimeLeft;
	private float lastFireTimeRight;

	private BroadsideCannon[] cannonBatteryLeft;
	private BroadsideCannon[] cannonBatteryRight;

	private BroadsideCannonsModel2 broadsideCannonsModel;

	void Awake(){
		broadsideCannonsModel = new BroadsideCannonsModel2 ();
	}

	void Start(){
		cannonBatteryLeft = GameObject.FindGameObjectWithTag ("CannonsBatteryLeft").GetComponentsInChildren<BroadsideCannon>();
		cannonBatteryRight = GameObject.FindGameObjectWithTag ("CannonsBatteryRight").GetComponentsInChildren<BroadsideCannon>();

		lastFireTimeLeft = Time.time;
		lastFireTimeRight = Time.time;
	}

	// ****************************************************************************************************************************************MODEL CONTROLLS START:

	public int CannonLevel{
		get {return broadsideCannonsModel.CannonLevel;}
		set {
			if (broadsideCannonsModel.CannonLevel == value) {
				return;
			} else if (value != 0 && value <=  broadsideCannonsModel.CannonMaxLevel) {
				broadsideCannonsModel.CannonLevel = value;
				if (OnCannonLevelChange != null) {
					OnCannonLevelChange (value);
				}
			}
		}
	}
	public delegate void OnCannonLevelChangeDelegate(int newVal);
	public event OnCannonLevelChangeDelegate OnCannonLevelChange;

	public void ChangeCannonLevel(float newLevel){
		CannonLevel = (int)newLevel;
	}

	//===================================================================================================================================================================


	public float CannonThrustForce{
		get {return broadsideCannonsModel.CannonThrustForce;}
		set {
			if (value == broadsideCannonsModel.CannonThrustForce) {
				return;
			} else if (value > 0 && value <= 100) {
				broadsideCannonsModel.CannonThrustForce = value;
				if (OnCannonThrustLevelChange != null) {
					OnCannonThrustLevelChange (value);
				}
			}
		}
	}
	public delegate void OnCannonThrustLevelChangeDelegate(float newVal);
	public event OnCannonThrustLevelChangeDelegate OnCannonThrustLevelChange;

	public void ChangeCannonThrustForce(float newCannonForce){
		CannonThrustForce = newCannonForce;
	}

	public float CannonsThrustMaxForce{
		get {return broadsideCannonsModel.CannonsThrustMaxForce;}
		set {
			if (value == broadsideCannonsModel.CannonsThrustMaxForce) {
				return;
			} else if (value != 0) {
				broadsideCannonsModel.CannonThrustForce = value;
				if (OnCannonThrustMaxLevelChange != null) {
					OnCannonThrustMaxLevelChange (value);
				}
			}
		}
	}
	public delegate void OnCannonThrustMaxLevelChangeDelegate(float newVal);
	public event OnCannonThrustMaxLevelChangeDelegate OnCannonThrustMaxLevelChange;

	//======================================================================================================================================================================

	public float CannonBallDistance{
		get {return broadsideCannonsModel.CannonBallDistance;}
		set {
			if (broadsideCannonsModel.CannonBallDistance == value) {
				return;
			} else if (value != 0) { //CHECK FOR MAX DISTANCE AND MIN DISTANCE HERE
				broadsideCannonsModel.CannonBallDistance = value;
				if (OnCannonBallDistanceChange != null) {
					OnCannonBallDistanceChange (value);
				}
			}
		}
	}
	public delegate void OnCannonBallDistanceChangeDelegate (float newVal);
	public event OnCannonBallDistanceChangeDelegate OnCannonBallDistanceChange;

	public void ChangeCannonBallDistance(float newCannonBallDistance){
		CannonBallDistance = newCannonBallDistance;
	}


	//======================================================================================================================================================================



	// FIRE CANNONS START

	public void FireCannonsLeft(){
		if (isReadyToFire (0)) {
			FireCannons (0);
		}else{
			Debug.Log ("Reloading left for another " + TimeToReadyToFireLeft () + " seconds");
		}
	}

	public void FireCannonsRight(){
		if (isReadyToFire (1)) {
			FireCannons (1);
		}else{
			Debug.Log ("Reloading right for another " + TimeToReadyToFireRight () + " seconds");
		}
	}

	public void FireCannons(int side){
		if (side == 0) {
			for (int i = 0; i < cannonBatteryLeft.Length; i++) {
				cannonBatteryLeft [i].FireCannon ();
			}
			lastFireTimeLeft = Time.time;
		} else if (side == 1) {
			for (int i = 0; i < cannonBatteryLeft.Length; i++) {
				cannonBatteryRight [i].FireCannon ();
			}
			lastFireTimeRight = Time.time;
		} else {
			Debug.LogError (0);
			//return 0;
		}

	}

	private bool isReadyToFire(int side){
		if (side == 0) {
			if (TimeToReadyToFireLeft () == 0f) {
				return true;
			} else {
				return false;
			}
		} else if (side == 1) {
			if (TimeToReadyToFireRight () == 0f) {
				return true;
			} else {
				return false;
			}
		} else {
			Debug.LogError ("Dunno what side?");
			return false;
		}
	}

	public float TimeToReadyToFireLeft(){
		float timeFromLastFire = Time.time - lastFireTimeLeft;
		float timeToReadToFireValue = broadsideCannonsModel.CannonReloadSpeed - timeFromLastFire;
		if (timeToReadToFireValue > 0f) {
			return timeToReadToFireValue;
		} else {
			return 0f;
		}
	}

	public float TimeToReadyToFireRight(){
		float timeFromLastFire = Time.time - lastFireTimeRight;
		float timeToReadToFireValue = broadsideCannonsModel.CannonReloadSpeed - timeFromLastFire;
		if (timeToReadToFireValue > 0f) {
			return timeToReadToFireValue;
		} else {
			return 0f;
		}
	}

}
