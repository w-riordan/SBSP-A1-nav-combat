public class ThrusterModel{
	//The power of the thruster
	public float power = 100;
	public float strength = .1f;

	//whether the truster is currently on
	public bool on = false;

	//Returns the current value of power
	public float GetPower (){
		return power;
	}

	//Sets the value of power
	public void setPower(float power){
		//Sets power to a value thats 0 or greater
		this.power = (power >= 0) ? power : 0;
	}

	//Returns whether the thruster is on
	public bool isOn(){
		return on;
	}

	//Set whether the truster is on or not
	public void setOn(bool on){
		this.on = on;
	}
		
	public float GetForce(){
		return power * strength;
	}
}
