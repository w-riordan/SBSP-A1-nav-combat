using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineView : MonoBehaviour {


	public Text powerText;
	public Text engineStateText;
	public Button onEngineButton;
	public Button offEngineButton;
	public Slider accSlider;

	private EngineController engineCont;


	private void Awake()
	{
		engineCont = GetComponent<EngineController>();
	}

	private void Start()
	{

		onEngineButton.onClick.AddListener(engineCont.TurnOnEngine);
		offEngineButton.onClick.AddListener(engineCont.TurnOffEngine);
		accSlider.onValueChanged.AddListener(delegate { engineCont.Accelerate(accSlider); });
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
		}
		else
		{
			engineStateString = "OFF";
			powerText.text = "Power : 0";
		}

		string engineStateMessage = "Engine : " + engineStateString;

		engineStateText.text = engineStateMessage;
	}

}