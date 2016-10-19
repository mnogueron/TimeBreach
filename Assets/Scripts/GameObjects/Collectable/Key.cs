using UnityEngine;
using System.Collections;

public class Key : Collectable {

    public AudioClip keyPickup;

    protected override void PickUp()
	{
		GameManager.AddKey();
        AudioSource.PlayClipAtPoint(keyPickup, transform.position);
        gameObject.SetActive(false);
	}

}
