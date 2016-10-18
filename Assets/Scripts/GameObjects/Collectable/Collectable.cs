using UnityEngine;
using System.Collections;

public abstract class Collectable : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUp();
        }
    }

    protected abstract void PickUp();

}
