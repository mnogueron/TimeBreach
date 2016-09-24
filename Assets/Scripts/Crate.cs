using UnityEngine;
using System.Collections;

public class Crate : Activable {

	public Transform crateColliderCheck;
	public LayerMask playerLayer;
	public float crateColliderRadius = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool collision = Physics2D.OverlapCircle (crateColliderCheck.position, crateColliderRadius, playerLayer);
		Debug.Log (collision);
		if(collision){
			if (!button.activeSelf) {
				button.SetActive (true);
			}
			button.transform.position = new Vector3(transform.position.x, transform.position.y + 0.65f, transform.position.z);
		}
		else{
			if (button.activeSelf) {
				button.SetActive (false);
			}	
		}
	}
}
