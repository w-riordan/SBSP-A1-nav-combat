using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrusterView : MonoBehaviour {

	public ThrusterController fl, fr, rl, rr;
	public Button turnLeft, turnRight, strafeLeft, strafeRight;
	public Slider powerSlider;
	public Text powerText;

	// Use this for initialization
	void Start () {
		turnLeft.onClick.AddListener (fr.FireThruster);
		turnLeft.onClick.AddListener (rl.FireThruster);
		turnRight.onClick.AddListener (fl.FireThruster);
		turnRight.onClick.AddListener (rr.FireThruster);

		strafeLeft.onClick.AddListener (fr.FireThruster);
		strafeLeft.onClick.AddListener (rr.FireThruster);
		strafeRight.onClick.AddListener (fl.FireThruster);
		strafeRight.onClick.AddListener (rl.FireThruster);

		powerSlider.onValueChanged.AddListener (delegate{fl.setPower(powerSlider.value);});
		powerSlider.onValueChanged.AddListener (delegate{fr.setPower(powerSlider.value);});
		powerSlider.onValueChanged.AddListener (delegate{rr.setPower(powerSlider.value);});
		powerSlider.onValueChanged.AddListener (delegate{rl.setPower(powerSlider.value);});
		powerSlider.onValueChanged.AddListener (delegate { powerText.text = "Power: "+powerSlider.value+"%"; });
	}
}
