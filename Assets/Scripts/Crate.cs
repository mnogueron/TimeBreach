using UnityEngine;
using System.Collections;

public class Crate : Activable {

	public float crateCheckRadius;

	private GameObject buttonDisabledSign;
    private Animator animator;


	public Crate() : base(){
		;
	}

	// Use this for initialization
	protected override void Start () {
		base.Start ();
        animator = GetComponent<Animator>();
		buttonDisabledSign = button.transform.FindChild ("Button").FindChild ("DisabledSign").gameObject;
		buttonDisabledSign.SetActive (false);
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
		if(button.activeSelf){
			if(!CanSwitchWorld () && !buttonDisabledSign.activeSelf){
				buttonDisabledSign.SetActive (true);
			} else if (CanSwitchWorld () && buttonDisabledSign.activeSelf){
				buttonDisabledSign.SetActive (false);
			}
			
		}
	}

	protected override void Activate(){
		//Debug.Log ("Crate can switch " + CanSwitchWorld () + " current world " + GameManager.instance.currentWorld);

		if (CanSwitchWorld() && Player.CanSwitchWorld ()) {
            Switch();
            //Debug.Log("Container " + transform.parent.gameObject.transform);
            //Debug.Log("New Layer" + LayerMask.LayerToName(transform.parent.gameObject.layer));

            GameManager.SwitchWorld ();

            animator.SetTrigger("zoomIn");

            //Debug.Log("New Current world " + GameManager.instance.currentWorld);
		}
	}

    private void Switch()
    {
        if (WorldManager.IsWorldFuture())
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
        return !Physics2D.OverlapCircle(activableColliderCheck.position, crateCheckRadius, WorldManager.GetOppositeLayerMask());
    }
}
