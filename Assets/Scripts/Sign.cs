using UnityEngine;
using System.Collections;

public class Sign : MonoBehaviour {

	public GameObject signText;
	public Transform signColliderCheck;
	public float minDistance;
	public bool signIsInFutureWorld;

	private string msgContent;

	// Use this for initialization
	void Start () {
		signText.GetComponent<MeshRenderer> ().enabled = false;
		msgContent = signText.GetComponent<TextMesh> ().text;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance(signColliderCheck.position, Player.instance.transform.position);

		// display the text only if the distance between the player and the sign
		// is small enough AND if the sign is in the same world as the Player
		if(distance < minDistance && areInSameWorld ()){
			signText.GetComponent<MeshRenderer> ().enabled = true;
		} else if(distance >= minDistance || !areInSameWorld ()){
			signText.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	// checks if the sign is in the current world
	private bool areInSameWorld(){
		return (signIsInFutureWorld && WorldManager.IsWorldFuture ());
	}
		
}
