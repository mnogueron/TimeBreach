using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public GameObject descriptionContainer;
	public Transform wallColliderCheck;
	public float minDistance;
	public bool wallIsInFutureWorld;

	// Use this for initialization
	void Start () {
		descriptionContainer.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
