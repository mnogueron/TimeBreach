using UnityEngine;
using System.Collections;

public class DieTrigger : MonoBehaviour {

	public float minDistance;

	private bool isFalling = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float distance = Vector3.Distance(transform.position, Player.instance.transform.position);
		if(distance <= minDistance && !isFalling)
		{
			isFalling = true;
			StartCoroutine(SceneController.ResetScene (0.5f));
		}
	}
}
