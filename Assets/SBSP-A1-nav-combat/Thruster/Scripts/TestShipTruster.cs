using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShipTruster : MonoBehaviour {

	public ThrusterController fl, fr, rl, rr;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		fr.truster.setOn (Input.GetKeyDown (KeyCode.LeftArrow));
		fl.truster.setOn (Input.GetKeyDown (KeyCode.RightArrow));
		rr.truster.setOn (Input.GetKeyDown (KeyCode.RightArrow));
		rl.truster.setOn (Input.GetKeyDown (KeyCode.LeftArrow));
	}
}
