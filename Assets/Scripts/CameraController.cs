using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	// Every camera should follow the user and be centered on him
	void LateUpdate () {
        transform.position = new Vector3(GameManager.Player().transform.position.x, GameManager.Player().transform.position.y, transform.position.z);
	}
}
