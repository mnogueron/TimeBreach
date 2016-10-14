using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

    // Use this for initialization
    void Start () {
        StartCoroutine(FadingBackground.FadeOutAsync());
    }
}
