using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutopilotController : MonoBehaviour {

	public ThrusterController fr, fl, rr, rl;

	private AutopilotModel autopilot;
	private Rigidbody rb;
	private float rotationalVelocityChange = 0.3f;//TODO Need to calculate this
	private bool turnRight = false;

	// Use this for initialization
	void Start () {
		autopilot = new AutopilotModel ();
		rb = GetComponent<Rigidbody> ();
	}
	

	// Update is called once per frame
	void Update () {
		if (autopilot.isAutopilotOn ()) {
			Debug.Log (" Rotational Velocity" +rb.angularVelocity.y);
			float currentHeading = ClampTo360(transform.rotation.eulerAngles.y);
			float distance = GetDistanceAndSetDirection (currentHeading);
			float targetRotVel;
			if (distance < 0.5f) {
				targetRotVel = 0;
			} else if (distance < 10) {
				targetRotVel = 0.3f;
			} else if (distance < 60) {
				targetRotVel = 0.5f;
			}else{
				targetRotVel = 1.1f;
			}
			TurnShip (targetRotVel);
		}
	}
	
	public void SetAutopilot(bool on){
		autopilot.setAutopilotOn (on);
	}

	public void SetTargetHeading(float heading){
		autopilot.setTargetHeading (heading);
	}

	private float ClampTo360(float value){
		while (value >= 360)
			value -= 360f;
		while (value < 0)
			value += 360f;
		return value;
	}

	private float GetDistanceAndSetDirection(float currentHeading){
		float leftDistance = 0, rightDistance = 0;
		if (currentHeading > autopilot.getTargetHeading ()) {
			leftDistance = currentHeading - autopilot.getTargetHeading ();
			rightDistance = autopilot.getTargetHeading () - (currentHeading - 360f);
		} else {
			rightDistance = autopilot.getTargetHeading () - currentHeading;
			leftDistance = (currentHeading + 360f) - autopilot.getTargetHeading ();
		}
		turnRight = rightDistance < leftDistance;
		return Mathf.Min (leftDistance, rightDistance);
	}

	private void TurnShip(float target){
		target = turnRight ? target : target * -1;
		float change = target - rb.angularVelocity.y;
		float power = (change / rotationalVelocityChange) < 0?(change / rotationalVelocityChange)*-1:(change / rotationalVelocityChange);
		SetPower(power*100);
		if (change > 0) {
			fl.FireThruster ();
			rr.FireThruster ();
		} else {
			fr.FireThruster ();
			rl.FireThruster ();
		}
	}

	private void SetPower(float p){
		fl.setPower (p);
		fr.setPower (p);
		rl.setPower (p);
		rr.setPower (p);
	}
}
