using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {

    // Use this for initialization
    void Start () {
        //StartCoroutine(FadingBackground.FadeOutAsync());
    }

	public static IEnumerator ResetScene(float fadeInDuration = -1f)
    {
		yield return FadingBackground.FadeInAsync(fadeInDuration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
