using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutopilotView : MonoBehaviour {

	public Toggle autopilotToggle;
	public Slider headingSlider;
	public Text targetHeadingText,currentHeading;
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

	void Update() {
		currentHeading.text = "Current Heading: " + Mathf.RoundToInt(apCon.GetCurrentHeading());
	}

	public void UpdateTargetHeading(float heading){
		apCon.SetTargetHeading (heading);
		heading = (heading < 0) ? heading + 360 : heading;
				targetHeadingText.text = "Target Heading: " + Mathf.RoundToInt(heading);
	}
}
