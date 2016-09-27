using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnToMainMenuOnClick : MonoBehaviour {

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
