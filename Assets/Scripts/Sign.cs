using UnityEngine;
using System.Collections;

public class Sign : MonoBehaviour {

	public GameObject signText;
	public Transform signColliderCheck;
	public float minDistance;

	private string msgContent;

	// Use this for initialization
	void Start () {
		signText.GetComponent<MeshRenderer> ().enabled = false;
		msgContent = signText.GetComponent<TextMesh> ().text;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance(signColliderCheck.position, Player.instance.transform.position);

		if(distance < minDistance){
			signText.GetComponent<MeshRenderer> ().enabled = true;
		} else if(distance >= minDistance){
			signText.GetComponent<MeshRenderer> ().enabled = false;
		}
	}
		
}
