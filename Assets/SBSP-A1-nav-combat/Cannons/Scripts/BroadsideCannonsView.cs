using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BroadsideCannonsView : MonoBehaviour {

	private CannonsController cannonsController;
	public BroadsideCannonsModel2 broadsideCannonsModel;

	public Text CannonsLevelDisplay;
	public Text ReloadLeftTimeDisplay;
	public Text ReloadRightTimeDisplay;

	public Text CannonsDistanceDisplay;
	public Text CannonsForceDisplay;

	public void ChangeCannonLevel(float newLevel){
		broadsideCannonsModel.CannonLevel = (int)newLevel;
		CannonsLevelDisplay.text = newLevel.ToString();
	}

	public void ChangeCannonThrustForce(float newForce){
		broadsideCannonsModel.CannonThrustForce = newForce;
		CannonsForceDisplay.text = newForce.ToString();
	}

	public void ChangeCannonDistance(float newDistance){
		broadsideCannonsModel.CannonBallDistance = newDistance;
		CannonsDistanceDisplay.text = newDistance.ToString();
	}

	void Start(){
		ReloadLeftTimeDisplay.text = "0";
		ReloadRightTimeDisplay.text = "0";
		cannonsController = FindObjectOfType<CannonsController> ();
		CannonsLevelDisplay.text = broadsideCannonsModel.CannonLevel.ToString();
		CannonsForceDisplay.text = broadsideCannonsModel.CannonThrustForce.ToString();
		CannonsDistanceDisplay.text = broadsideCannonsModel.CannonBallDistance.ToString();
	}

	private void LevelChangeHandler(int newLevel)
	{
		ChangeCannonLevel (newLevel);
	}

	private void ForceChangeHandler(float newForce)
	{
		ChangeCannonThrustForce (newForce);
		Debug.LogError (14);
	}

	private void DistanceChangeHandler(float newDistance)
	{
		ChangeCannonDistance (newDistance);
		Debug.LogError (15);
	}

	void OnEnable(){
		broadsideCannonsModel.OnCannonLevelChange += LevelChangeHandler;
		broadsideCannonsModel.OnCannonThrustLevelChange += ForceChangeHandler;
		broadsideCannonsModel.OnCannonBallDistanceChange += DistanceChangeHandler;
	}
	void OnDisable(){
		broadsideCannonsModel.OnCannonLevelChange -= LevelChangeHandler;
		broadsideCannonsModel.OnCannonThrustLevelChange -= ForceChangeHandler;
		broadsideCannonsModel.OnCannonBallDistanceChange -= DistanceChangeHandler;
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
		if (ReloadRightTimeDisplay.text != "Ready" || cannonsController.TimeToReadyToFireLeft () != 0) {
			if (cannonsController.TimeToReadyToFireRight () != 0) {
				ReloadRightTimeDisplay.text = cannonsController.TimeToReadyToFireRight ().ToString ();
			} else {
				ReloadRightTimeDisplay.text = "Ready";
			}
		}
	}
}
