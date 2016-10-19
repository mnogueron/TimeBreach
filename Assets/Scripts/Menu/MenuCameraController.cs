using UnityEngine;
using System.Collections;

public class MenuCameraController : MonoBehaviour {

    void LateUpdate()
    {
        transform.position = new Vector3(MenuPlayer.instance.transform.position.x, MenuPlayer.instance.transform.position.y, transform.position.z);
    }
}
