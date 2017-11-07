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
		rbody =GetComponentsInParent<Rigidbody> ()[0];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//If the thruster is switched on
		if (truster.isOn ()) {
			Debug.Log ("Force Applied");	
			//Apply force in the direction the thrusters facing at position(Fire the thruster)
			rbody.AddForceAtPosition ((-transform.forward) * truster.GetForce (), transform.position);
			//
			truster.setOn (false);
		} else {
			
		}
	}

	public void FireThruster(){
		Debug.Log ("FIRE TRUSTER");
		truster.setOn (true);
		Debug.Log (truster.isOn ());
	}

	public void setPower(float value){
		truster.setPower (value);
	}

}
