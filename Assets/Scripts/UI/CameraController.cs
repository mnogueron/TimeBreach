using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	// Every camera should follow the user and be centered on him
	void LateUpdate () {
        transform.position = new Vector3(Player.instance.transform.position.x, Player.instance.transform.position.y, transform.position.z);
	}
}
