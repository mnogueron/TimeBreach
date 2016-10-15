using UnityEngine;
using System.Collections;

public class Orbem : Collectable {

	public GameObject orbemText;
	public Transform orbemColliderCheck;
	public float minDistance;

	// Use this for initialization
	void Start () {
		orbemText.GetComponent<MeshRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance(orbemColliderCheck.position, Player.instance.transform.position);

		if(distance < minDistance){
			orbemText.GetComponent<MeshRenderer> ().enabled = true;
		} else if(distance >= minDistance){
			orbemText.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	protected override void PickUp()
	{
		gameObject.SetActive(false);
		Player.SetHasOrbem (true);
		Debug.Log (Player.HasOrbem ());
		UIManager.ShowPowerBar ();
	}
}
