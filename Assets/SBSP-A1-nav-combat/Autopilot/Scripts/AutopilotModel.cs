using UnityEngine;

public class AutopilotModel {
	float targetHeading=0;
	float targetVelocity=0f;
	bool autopilotOn=false;

	//Set the target heading in degrees
	public void setTargetHeading(float heading){
		while (heading < 0) 
			heading += 360f;
		while (heading >= 360)
			heading -= 360f;

		//Set the heading
		targetHeading = heading;
	}

	//return the target heading
	public float getTargetHeading(){
		return targetHeading;
	}

	//Switch the autopilot on or off
	public void setAutopilotOn(bool on){
		autopilotOn = on;
	}

	//Get whether the autopilot is switched on or not
	public bool isAutopilotOn(){
		return autopilotOn;
	}
}
