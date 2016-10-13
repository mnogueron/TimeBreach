using UnityEngine;
using System.Collections;

public abstract class Raisable : MonoBehaviour {

	// Use this for initialization
	protected abstract void Start ();
	
	// Activate is called to raise the raisable object
	public abstract void Activate();

	// Deactivate is called to lower the raisable object
	public abstract void Deactivate();
}
