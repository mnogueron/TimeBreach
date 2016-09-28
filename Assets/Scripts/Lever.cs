using UnityEngine;
using System.Collections;

public class Lever : Activable {

	public Elevator elevator;

	private GameObject leverInactive;
	private GameObject leverActive;
	private bool isActive;

	public Lever() : base(){
		;
	}

	// Use this for initialization
	protected override void Start () {
		base.Start ();

		Debug.Log (transform.FindChild("LeverSprite"));

		leverInactive = transform.FindChild("lever-inactive").gameObject;
		leverActive = transform.FindChild("lever-active").gameObject;
		leverInactive.SetActive (true);
		leverActive.SetActive (false);
		isActive = false;
	}
	
	protected override void Activate(){
		if (!isActive) {
			// activate the lever
			leverInactive.SetActive (false);
			leverActive.SetActive (true);
			elevator.Activate ();
		} else {
			// deactivate the lever
			leverInactive.SetActive (true);
			leverActive.SetActive (false);
			elevator.Deactivate ();
		}
		isActive = !isActive;
	}

}
