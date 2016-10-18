using UnityEngine;
using System.Collections;

public class Key : Collectable {

    protected override void PickUp()
	{
		GameManager.AddKey();
        AudioSource.PlayClipAtPoint(AudioManager.instance.keyPickup, transform.position);
        gameObject.SetActive(false);
	}

}
