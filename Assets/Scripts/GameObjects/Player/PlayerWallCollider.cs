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
        if (CollisionIsValid(hit))
        {
            parent.OnWallTriggerStay2D(hit);
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        if (CollisionIsValid(hit))
        {
            parent.OnWallTriggerExit2D(hit);
        }
    }

    bool CollisionIsValid(Collider2D hit)
    {
        if (WorldManager.IsWorldFuture())
        {
            return ((WorldManager.FutureWorldLayer().value & 1 << hit.transform.gameObject.layer) != 0 || hit.tag == "Crate") && hit.tag != "Collectable";
        }
        else
        {
            return ((WorldManager.PresentWorldLayer().value & 1 << hit.transform.gameObject.layer) != 0 || hit.tag == "Crate") && hit.tag != "Collectable";
        }
    }
}
