using UnityEngine;
using System.Collections;

public abstract class Activable : MonoBehaviour {

	public GameObject button;
	public Transform activableColliderCheck;
	public float minDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		float distance = Vector2.Distance (activableColliderCheck.position, GameManager.Player ().transform.position);

		if(distance <= minDistance){
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

	void LateUpdate(){
		// check E pressed down
		if(Input.GetKeyDown (KeyCode.E) && button.activeSelf){
			Activate ();
		}
	}

	protected abstract void Activate ();
}
