using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutopilotView : MonoBehaviour {

	public Toggle autopilotToggle;
	public Slider headingSlider;
	public Text headingText;
	private AutopilotController apCon;
	// Use this for initialization
	void Start () {
		apCon = GetComponent<AutopilotController> ();


		autopilotToggle.onValueChanged.AddListener (delegate {
			apCon.SetAutopilot(autopilotToggle.isOn);
		});
		headingSlider.onValueChanged.AddListener (delegate {
			UpdateTargetHeading(headingSlider.value);
		});

	}

	public void UpdateTargetHeading(float heading){
		apCon.SetTargetHeading (heading);
		headingText.text = "Heading: "+heading;
	}
}
