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
		//Debug.Log ("Crate can switch " + CanSwitchWorld () + " current world " + GameManager.instance.currentWorld);

		if (CanSwitchWorld () && GameManager.Player ().CanSwitchWorld ()) {
            Switch();
            //Debug.Log("Container " + transform.parent.gameObject.transform);
            //Debug.Log("New Layer" + LayerMask.LayerToName(transform.parent.gameObject.layer));

            GameManager.SwitchWorld ();

            //Debug.Log("New Current world " + GameManager.instance.currentWorld);
        }
	}

    private void Switch()
    {
        if (GameManager.IsWorldFuture())
        {
            // switch player + crateContainer to the PRESENT
            transform.parent.gameObject.transform.position = new Vector3(transform.parent.gameObject.transform.position.x, transform.parent.gameObject.transform.position.y, 60f);
            transform.parent.gameObject.SetLayer(LayerMask.NameToLayer("Items World Present"), true);
        }
        else
        {
            // switch player + crateContainer to the FUTURE
            transform.parent.gameObject.transform.position = new Vector3(transform.parent.gameObject.transform.position.x, transform.parent.gameObject.transform.position.y, 0f);
            transform.parent.gameObject.SetLayer(LayerMask.NameToLayer("Items World Future"), true);
        }
    }

	bool CanSwitchWorld(){
        LayerMask toCheck = (GameManager.IsWorldFuture()) ? GameManager.PresentWorldLayer() : GameManager.FutureWorldLayer();
        return !Physics2D.OverlapCircle(activableColliderCheck.position, crateCheckRadius, toCheck);
    }
}
