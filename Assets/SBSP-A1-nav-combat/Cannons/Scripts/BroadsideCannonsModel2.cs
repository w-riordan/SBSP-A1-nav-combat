public class BroadsideCannonsModel2 {

	private int cannonLevel = 1;
	public int CannonLevel{ get {return cannonLevel;} set{cannonLevel = value;}}

	private int cannonMaxLevel = 4;
	public int CannonMaxLevel{ get {return cannonMaxLevel;} }

	private float cannonBaseDamage = 100f;
	private float baseReloadTime = 10f;

	public float CannonReloadSpeed{ get {return baseReloadTime/cannonLevel;}}

	private float cannonThrustForce = 100f;
	public float CannonThrustForce{ get {return cannonThrustForce;} set {cannonThrustForce = value;}}

	private float cannonBallDistance = 10f;
	public float CannonBallDistance{ get { return cannonBallDistance; } set { cannonBallDistance = value; } }

	private int cannonsBaseMaxForce = 100;
	public float CannonsThrustMaxForce { get {return cannonsBaseMaxForce * cannonLevel;}}
}