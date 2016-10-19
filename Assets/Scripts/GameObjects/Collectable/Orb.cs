using UnityEngine;
using System.Collections;

public class Orb : Collectable {

    public AudioClip orbPickup;

	protected override void PickUp()
	{
        AudioSource.PlayClipAtPoint(orbPickup, transform.position);
		Player.SetHasOrbem (true);
		UIManager.ShowPowerBar ();
        gameObject.SetActive(false);
    }
}
