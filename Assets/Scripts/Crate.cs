using UnityEngine;
using System.Collections;

public class Crate : Activable {

	public float crateCheckRadius;

	public Crate() : base(){
		;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
	}

	protected override void Activate(){
		Debug.Log ("Pressed E key");
		Debug.Log ("Crate can switch " + CanSwitchWorld ());

		if (CanSwitchWorld () && GameManager.Player ().CanSwitchWorld ()) {
			if (GameManager.instance.currentWorld.CompareTo (GameManager.World.FUTURE) == 0) {
				// switch player + crateContainer to the PRESENT
				transform.parent.gameObject.transform.position = new Vector3 (transform.parent.gameObject.transform.position.x, transform.parent.gameObject.transform.position.y, 60f);
				transform.parent.gameObject.layer = LayerMask.NameToLayer ("Items World Present");
			}
			else if(GameManager.instance.currentWorld.CompareTo (GameManager.World.PRESENT) == 0){
				// switch player + crateContainer to the FUTURE
				transform.parent.gameObject.transform.position = new Vector3 (transform.parent.gameObject.transform.position.x, transform.parent.gameObject.transform.position.y, 0f);
				transform.parent.gameObject.layer = LayerMask.NameToLayer ("Items World Future");
			}
			GameManager.SwitchWorld ();
		}
	}

	bool CanSwitchWorld(){
		return (GameManager.instance.currentWorld.CompareTo(GameManager.World.FUTURE) == 0) ? !Physics2D.OverlapCircle(activableColliderCheck.position, crateCheckRadius, GameManager.PresentWorldLayer ()) : !Physics2D.OverlapCircle(activableColliderCheck.position, crateCheckRadius, GameManager.FutureWorldLayer ());
	}
}
