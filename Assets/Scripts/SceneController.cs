using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {

    // Use this for initialization
    void Start () {
        StartCoroutine(FadingBackground.FadeOutAsync());
    }

    public static IEnumerator ResetScene()
    {
        yield return FadingBackground.FadeInAsync();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
