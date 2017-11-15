using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add ThrusterController to thruster object
public class ThrusterController : MonoBehaviour {

	public ThrusterModel truster;
	private Rigidbody rbody;
	void Start () {
		//Create new ThrusterModel object
		if (truster == null) {
			truster = new ThrusterModel ();
		}
		//Get the Rigidbody of the shipobject(Parent object)
		rbody =GetComponentInParent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//If the thruster is switched on
		if (truster.isOn ()) {
			//Apply force in the direction the thrusters facing at position(Fire the thruster)
			rbody.AddForceAtPosition ((-transform.forward) * truster.GetForce (), transform.position);
			//
			truster.setOn (false);
		}
	}

	public void FireThruster(){
		truster.setOn (true);
	}

	public void setPower(float value){
		truster.setPower (value);
	}

}
