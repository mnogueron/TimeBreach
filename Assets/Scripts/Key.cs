using UnityEngine;
using System.Collections;

public class Key : Collectable {

	protected override void PickUp()
	{
		GameManager.AddKey();
		gameObject.SetActive(false);
	}

}
