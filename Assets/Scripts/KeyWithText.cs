using UnityEngine;
using System.Collections;

public class KeyWithText : Collectable
{
	public GameObject keyText;
	public Transform keyColliderCheck;
	public float minDistance;

	// Use this for initialization
	void Start () {
		keyText.GetComponent<MeshRenderer> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance(keyColliderCheck.position, Player.instance.transform.position);

		if(distance < minDistance){
			keyText.GetComponent<MeshRenderer> ().enabled = true;
		} else if(distance >= minDistance){
			keyText.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

    protected override void PickUp()
    {
        GameManager.AddKey();
        gameObject.SetActive(false);
    }
		
}
