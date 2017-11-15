using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BroadsideCannonsView : MonoBehaviour {

	public CannonsController cannonsController;

	public Text CannonsLevelDisplay;
	public Text ReloadLeftTimeDisplay;
	public Text ReloadRightTimeDisplay;

	public Text CannonsDistanceDisplay;
	public Text CannonsForceDisplay;


	void Start(){

		cannonsController = FindObjectOfType<CannonsController> ();
	
		CannonsLevelDisplay.text = cannonsController.CannonLevel.ToString();
		CannonsForceDisplay.text = cannonsController.CannonThrustForce.ToString()+"%";
		CannonsDistanceDisplay.text = cannonsController.CannonBallDistance.ToString ();
	}


	private void LevelChangeHandler(int newLevel)
	{
		ChangeCannonLevelDisplay (newLevel);
	}

	private void ChangeCannonLevelDisplay(float newLevel){
		CannonsLevelDisplay.text = newLevel.ToString();
	}


	public void ChangeCannonThrustForceDisplay(float newForce){
		CannonsForceDisplay.text = newForce.ToString () + "%";
	}
	private void ForceChangeHandler(float newForce)
	{
		ChangeCannonThrustForceDisplay (newForce);
	}


	private void DistanceChangeHandler(float newDistance)
	{
		ChangeCannonDistanceDisplay (newDistance);
	}
	public void ChangeCannonDistanceDisplay(float newDistance){
		CannonsDistanceDisplay.text = newDistance.ToString();
	}

	void OnEnable(){
		cannonsController.OnCannonLevelChange += LevelChangeHandler;
		cannonsController.OnCannonThrustLevelChange += ForceChangeHandler;
		cannonsController.OnCannonBallDistanceChange += DistanceChangeHandler;
	}
	void OnDisable(){
		cannonsController.OnCannonLevelChange -= LevelChangeHandler;
		cannonsController.OnCannonThrustLevelChange -= ForceChangeHandler;
		cannonsController.OnCannonBallDistanceChange -= DistanceChangeHandler;
	}

	void Update(){
		updateReloadDisplay ();
	}

	private void updateReloadDisplay(){
		if (ReloadLeftTimeDisplay.text != "Ready" || cannonsController.TimeToReadyToFireLeft () != 0) {
			if (cannonsController.TimeToReadyToFireLeft () != 0) {
				ReloadLeftTimeDisplay.text = cannonsController.TimeToReadyToFireLeft ().ToString ();
			} else {
				ReloadLeftTimeDisplay.text = "Ready";
			}
		}
		if (ReloadRightTimeDisplay.text != "Ready" || cannonsController.TimeToReadyToFireRight () != 0) {
			if (cannonsController.TimeToReadyToFireRight () != 0) {
				ReloadRightTimeDisplay.text = cannonsController.TimeToReadyToFireRight ().ToString ();
			} else {
				ReloadRightTimeDisplay.text = "Ready";
			}
		}
	}
}
