using UnityEngine;
using System.Collections;

public class Elevator : Raisable {

	private GameObject elevatorDown;
	private GameObject elevatorUp;

	public Elevator() : base(){
		;
	}

	// Use this for initialization
	protected override void Start () {
		elevatorDown = transform.FindChild ("elevator-down").gameObject;
		elevatorUp = transform.FindChild ("elevator-up").gameObject;
		elevatorDown.SetActive (true);
		elevatorUp.SetActive (false);
	}

	public override void Activate(){
		elevatorDown.SetActive (false);
		elevatorUp.SetActive (true);
	}

	public override void Deactivate(){
		elevatorDown.SetActive (true);
		elevatorUp.SetActive (false);
	}
}
