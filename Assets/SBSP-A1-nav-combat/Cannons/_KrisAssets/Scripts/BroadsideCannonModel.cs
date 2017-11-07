using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BroadsideCannonModel {

	private static int cannonLevel = 1;
	public static int CannonLevel{
		get {return cannonLevel;}
		set {
			if (cannonLevel == value) {
				return;
			} else {
				cannonLevel = value;
				if (OnCannonLevelChange != null) {
					OnCannonLevelChange (cannonLevel);
					if (cannonLevel != 0) {
						cannonReloadSpeed = baseReloadTime / cannonLevel;
					}
					//Debug.LogError ("cannonReloadSpeed = " + cannonReloadSpeed);
				}
			}
		}
	}
	public delegate void OnCannonLevelChangeDelegate(int newVal);
	public static event OnCannonLevelChangeDelegate OnCannonLevelChange;

	private static float baseReloadTime = 10f;
	private static float cannonReloadSpeed = baseReloadTime;
	public static float CannonReloadSpeed{ get {return cannonReloadSpeed;}}

	/*
	public static float CannonReloadSpeed{
		get {return cannonReloadSpeed;}
		set {
			if (cannonReloadSpeed == value) {
				return;
			} else {
				cannonReloadSpeed = value;
				if (OnVariableChange != null) {
					OnVariableChange (cannonReloadSpeed);
				}
			}
		}
	}
	public delegate void OnReloadChangeDelegate(float newVal);
	public static event OnReloadChangeDelegate OnReloadChange;
	*/

	private static float cannonThrustForce;
	private static float cannonBaseDamage;
}
