using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LoadingController : MonoBehaviour {

    public List<string> listOfLevels;
    public Text loadingText;

    // Use this for initialization
    void Start () {
        loadingText.text = SceneLoader.instance.currentLoadingText;
    }
}
