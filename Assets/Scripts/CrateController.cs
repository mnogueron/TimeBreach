using UnityEngine;
using System.Collections;

public class CrateController : MonoBehaviour {

    public GameObject button;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        button.transform.position = new Vector3(transform.position.x, transform.position.y + 0.65f, transform.position.z);
	}
}
