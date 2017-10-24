using System.Collections;
using UnityEngine;

public class DestroyRadarObjectTest : MonoBehaviour {

	//Test to destroy Object
	void OnTriggerEnter(Collider hit)
	{
		if (hit.CompareTag ("Enemy")) 
		{ 
			Destroy(hit.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
