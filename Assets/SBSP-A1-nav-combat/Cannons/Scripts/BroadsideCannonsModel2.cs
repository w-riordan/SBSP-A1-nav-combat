using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadsideCannonsModel2 : MonoBehaviour {

	private int cannonLevel = 1;

	public int CannonLevel{
		get {return cannonLevel;}
		set {
			if (cannonLevel == value) {
				return;
			} else {
				if (OnCannonLevelChange != null) {
					OnCannonLevelChange (cannonLevel);
					if (cannonLevel != 0) {
						cannonLevel = value;
						cannonReloadSpeed = baseReloadTime / cannonLevel;
					}
					//Debug.LogError ("cannonReloadSpeed = " + cannonReloadSpeed);
				}
			}
		}
	}

	public delegate void OnCannonLevelChangeDelegate(int newVal);
	public event OnCannonLevelChangeDelegate OnCannonLevelChange;

	private float baseReloadTime = 10f;
	private float cannonReloadSpeed = 10f;
	public float CannonReloadSpeed{ get {return cannonReloadSpeed;}}

	private float cannonThrustForce = 100f;
	public float CannonThrustForce{
		get {return cannonThrustForce;}
		set {
			if (cannonThrustForce == value) {
				return;
			} else {
				if (OnCannonThrustLevelChange != null) {
					if (cannonThrustForce != 0) {
						OnCannonThrustLevelChange (cannonThrustForce);
						cannonThrustForce = value;
					}
				}
			}
		}
	}

	public delegate void OnCannonThrustLevelChangeDelegate(float newVal);
	public event OnCannonThrustLevelChangeDelegate OnCannonThrustLevelChange;

	private float cannonBallDistance = 10f;
	public float CannonBallDistance{
		get {return cannonBallDistance;}
		set {
			if (cannonBallDistance == value) {
				return;
			} else {
				if (OnCannonBallDistanceChange != null) {
					//Debug.LogError (1);
					if (cannonBallDistance != 0) {
						cannonBallDistance = value;
						OnCannonBallDistanceChange (cannonBallDistance);
					}
				}
			}
		}
	}

	public delegate void OnCannonBallDistanceChangeDelegate (float newVal);
	public event OnCannonBallDistanceChangeDelegate OnCannonBallDistanceChange;

	private float cannonBaseDamage;
}
