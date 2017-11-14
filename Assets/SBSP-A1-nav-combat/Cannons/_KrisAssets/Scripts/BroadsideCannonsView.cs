using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BroadsideCannonsView : MonoBehaviour {

	public Text CannonsLevelDisplay;
	public Text ReloadLeftTimeDisplay;
	public Text ReloadRightTimeDisplay;
	private CannonsController cannonsController;

	public void ChangeCannonLevel(float newLevel){
		BroadsideCannonModel.CannonLevel = (int)newLevel;
		CannonsLevelDisplay.text = newLevel.ToString();
	}

	void Start(){
		ReloadLeftTimeDisplay.text = "0";
		ReloadRightTimeDisplay.text = "0";
		cannonsController = FindObjectOfType<CannonsController> ();
		CannonsLevelDisplay.text = BroadsideCannonModel.CannonLevel.ToString();
	}

	void Update(){
		updateReloadDisplay ();
	}

	private void updateReloadDisplay(){
		ReloadLeftTimeDisplay.text = cannonsController.TimeToReadyToFireLeft ().ToString ();
		ReloadRightTimeDisplay.text = cannonsController.TimeToReadyToFireRight ().ToString ();
	}
}
