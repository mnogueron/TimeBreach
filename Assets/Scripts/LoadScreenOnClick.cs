using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScreenOnClick : MonoBehaviour {

	public void LoadByName(string sceneName)
    {
        SceneLoader.LoadNextScene();
        //SceneManager.LoadScene(sceneName); 
    }
}
