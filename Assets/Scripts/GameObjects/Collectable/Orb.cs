using UnityEngine;
using System.Collections;

public class Orb : Collectable {

	protected override void PickUp()
	{
        Debug.Log("inside pickup");
		gameObject.SetActive(false);
		Player.SetHasOrbem (true);
		Debug.Log (Player.HasOrbem ());
		UIManager.ShowPowerBar ();
	}
}
