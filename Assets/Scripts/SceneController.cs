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
		Debug.Log ("Fading finished");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
