using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	private GameObject elevatorDown;
	private GameObject elevatorUp;

	// Use this for initialization
	public void Start () {
		elevatorDown = transform.FindChild ("elevator-down").gameObject;
		elevatorUp = transform.FindChild ("elevator-up").gameObject;
		elevatorDown.SetActive (true);
		elevatorUp.SetActive (false);
	}

	public void Activate(){
		elevatorDown.SetActive (false);
		elevatorUp.SetActive (true);
	}

	public void Deactivate(){
		elevatorDown.SetActive (true);
		elevatorUp.SetActive (false);
	}
}
