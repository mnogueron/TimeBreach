using UnityEngine;
using System.Collections;

public class Orb : Collectable {

	public GameObject orbText;
	public Transform orbColliderCheck;
	public float minDistance;

	// Use this for initialization
	void Start () {
		orbText.GetComponent<MeshRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance(orbColliderCheck.position, Player.instance.transform.position);

		if(distance < minDistance){
			orbText.GetComponent<MeshRenderer> ().enabled = true;
		} else if(distance >= minDistance){
			orbText.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	protected override void PickUp()
	{
        Debug.Log("inside pickup");
		gameObject.SetActive(false);
        orbText.SetActive(false);
		Player.SetHasOrbem (true);
		Debug.Log (Player.HasOrbem ());
		UIManager.ShowPowerBar ();
	}
}
