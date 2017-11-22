using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {
	private float timeToArm = 0f;
	private float timeToDetonate;
	private float timeToArmLeft;
	private float explosionRange;
	private float baseDamage;
	private float startTime = 0f;

	// todo range of explosion - collision dettection
	// inflict damage method
	// timeToArm

	public void setTimeToArm(float tta){timeToArm = tta;}
	public void setTimeToDetonate(float ttd){timeToDetonate = ttd;}
	public void setExplosionRange(float er){explosionRange = er;}
	public void setBaseDamage(float dmg){baseDamage = dmg;}

	void Start(){
		Invoke("Detonate", timeToDetonate);
	}

	private int counter = 0;
	private float deltaTime = 0f;

	void Update(){/*
		if (counter % 100 == 0) {
			//Debug.LogError("timeToArm :" + timeToArm);
			//Debug.LogError("timeToDetonate :" + timeToDetonate);
			//deltaTime = Time.time - startTime;
			//Debug.Log ("Delta time = " + deltaTime);
			timeToArmLeft = timeToArm - deltaTime;
			//Debug.Log ("timeToArmLeft :" + timeToArmLeft);
		}
		counter += 1;
		*/
	}

	void OnCollisionEnter(Collision collision){
		Detonate ();
	}

	public void Detonate(){
		Debug.Log ("BOOM");
		Destroy (gameObject);
	}
}
