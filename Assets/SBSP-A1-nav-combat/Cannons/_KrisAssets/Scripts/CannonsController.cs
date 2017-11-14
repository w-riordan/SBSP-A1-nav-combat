using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonsController : MonoBehaviour {

	private float lastFireTimeLeft;
	private float lastFireTimeRight;

	private BroadsideCannon[] cannonBatteryLeft;
	private BroadsideCannon[] cannonBatteryRight;

	void Start(){
		cannonBatteryLeft = GameObject.FindGameObjectWithTag ("CannonsBatteryLeft").GetComponentsInChildren<BroadsideCannon>();
		cannonBatteryRight = GameObject.FindGameObjectWithTag ("CannonsBatteryRight").GetComponentsInChildren<BroadsideCannon>();

		lastFireTimeLeft = Time.time;
		lastFireTimeRight = Time.time;
	}

	public void FireCannonsLeft(){
		if (isReadyToFire (0)) {
			FireCannons (0);
		}else{
			Debug.Log ("Reloading for another " + TimeToReadyToFireLeft () + " seconds");
		}
	}

	public void FireCannonsRight(){
		if (isReadyToFire (1)) {
			FireCannons (1);
		}else{
			Debug.Log ("Reloading for another " + TimeToReadyToFireRight () + " seconds");
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
		float timeToReadToFireValue = BroadsideCannonModel.CannonReloadSpeed - timeFromLastFire;
		if (timeToReadToFireValue > 0f) {
			return timeToReadToFireValue;
		} else {
			return 0f;
		}
	}

	public float TimeToReadyToFireRight(){
		float timeFromLastFire = Time.time - lastFireTimeRight;
		float timeToReadToFireValue = BroadsideCannonModel.CannonReloadSpeed - timeFromLastFire;
		if (timeToReadToFireValue > 0f) {
			return timeToReadToFireValue;
		} else {
			return 0f;
		}
	}

}
