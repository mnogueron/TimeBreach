using UnityEngine;
using System.Collections;

public class PlayerWallCollider : MonoBehaviour {

    private Player parent;

	// Use this for initialization
	void Start () {
        parent = transform.parent.GetComponent<Player>();
	}
	
	void OnTriggerStay2D(Collider2D hit)
    {
        if (WorldManager.IsWorldFuture())
        {
            if(hit.transform.gameObject.layer == LayerMask.NameToLayer("World Future"))
            {
                parent.OnWallTriggerStay2D(hit);
            }
        }
        else
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("World Present"))
            {
                parent.OnWallTriggerStay2D(hit);
            }
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        if (WorldManager.IsWorldFuture())
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("World Future"))
            {
                parent.OnWallTriggerExit2D(hit);
            }
        }
        else
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("World Present"))
            {
                parent.OnWallTriggerExit2D(hit);
            }
        }
    }
}
