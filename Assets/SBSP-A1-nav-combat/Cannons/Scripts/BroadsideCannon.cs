using UnityEngine;

public class BroadsideCannon : MonoBehaviour {

	public CannonBall cannonBallPrefab;
	private CannonsController cannonsController;

	void Start(){
		cannonsController = FindObjectOfType<CannonsController> ();
	}
	
	public void FireCannon(){
		CannonBall newBall = Instantiate (cannonBallPrefab, transform.position, transform.rotation);
		newBall.setTimeToArm (30f);
		newBall.setTimeToDetonate (cannonsController.CannonBallDistance);
		Rigidbody rigidbody;
		rigidbody = newBall.GetComponent<Rigidbody>();
		rigidbody.AddForce(transform.up * cannonsController.CannonThrustForce * cannonsController.CannonsThrustMaxForce);
	}
}
