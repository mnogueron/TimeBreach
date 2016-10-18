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
            if((WorldManager.FutureWorldLayer().value & 1<<hit.transform.gameObject.layer) != 0 || hit.tag == "Crate")
            {
                parent.OnWallTriggerStay2D(hit);
            }
        }
        else
        {
            if ((WorldManager.PresentWorldLayer().value & 1 << hit.transform.gameObject.layer) != 0 || hit.tag == "Crate")
            {
                parent.OnWallTriggerStay2D(hit);
            }
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        if (WorldManager.IsWorldFuture())
        {
            if ((WorldManager.FutureWorldLayer().value & 1 << hit.transform.gameObject.layer) != 0 || hit.tag == "Crate")
            {
                parent.OnWallTriggerExit2D(hit);
            }
        }
        else
        {
            if ((WorldManager.PresentWorldLayer().value & 1 << hit.transform.gameObject.layer) != 0 || hit.tag == "Crate")
            {
                parent.OnWallTriggerExit2D(hit);
            }
        }
    }
}
