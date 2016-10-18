using UnityEngine;
using System.Collections;

public class Sign : MonoBehaviour {

	public GameObject descriptionContainer;
	public Transform signColliderCheck;
	public float minDistance;
	public bool signIsInFutureWorld;

	// Use this for initialization
	void Start () {
		descriptionContainer.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance(signColliderCheck.position, Player.instance.transform.position);

		// display the text only if the distance between the player and the sign
		// is small enough AND if the sign is in the same world as the Player
		if(distance < minDistance && areInSameWorld ()){
			descriptionContainer.SetActive (true);
		} else if(distance >= minDistance || !areInSameWorld ()){
			descriptionContainer.SetActive (false);
		}
	}

	// checks if the sign is in the current world
	private bool areInSameWorld(){
		return (signIsInFutureWorld && WorldManager.IsWorldFuture ());
	}
		
}
