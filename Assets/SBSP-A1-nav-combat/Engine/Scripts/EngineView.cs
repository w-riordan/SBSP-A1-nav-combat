using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineView : MonoBehaviour {


	public Text powerText;
	public Text engineStateText;
	public Slider accSlider;
	public Toggle toggle;
	public Text toggleText;

	private EngineController engineCont;


	private void Awake()
	{
		engineCont = GetComponent<EngineController>();
	}

	private void Start()
	{
		toggle.isOn = false;
		toggle.onValueChanged.AddListener(delegate { ToggleButtonEngine(); });
		accSlider.onValueChanged.AddListener(delegate { engineCont.Accelerate(accSlider); });
		accSlider.interactable = false;
	}

	//update text message for the power value
	public void UpdatePower(float power)
	{
		string powerMessage = "Power : " + power;

		//update UI on the screen with the message
		powerText.text = powerMessage;

	}

	public void UpdateEngineState(bool engineState)
	{
		string engineStateString;

		if (engineState)
		{
			engineStateString = "ON";
			accSlider.interactable = true;

		}
		else
		{
			engineStateString = "OFF";
			powerText.text = "Power : 0";
			accSlider.value = 0;
			accSlider.interactable = false;
		}

		string engineStateMessage = "Engine : " + engineStateString;

		engineStateText.text = engineStateMessage;
	}

	public void ToggleButtonEngine(){
		if (toggle.isOn) {
			toggleText.text = "ON";
			engineCont.TurnOnEngine();
		} else {
			toggleText.text = "OFF";
			engineCont.TurnOffEngine();
		}
	}

}