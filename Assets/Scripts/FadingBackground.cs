using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadingBackground : MonoBehaviour {

    public static FadingBackground instance;

    public Image image;

    public float fadeInDuration = 1.5f;
    public float fadeOutDuration = 1.5f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            image.enabled = false;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static float GetFadeInDuration()
    {
        return instance.fadeInDuration;
    }

    public static float GetFadeOutDuration()
    {
        return instance.fadeOutDuration;
    }

	public static IEnumerator FadeInAsync(float fadeInDuration = -1f)
    {
		float concreteFadeInDuration = fadeInDuration != -1f ? fadeInDuration : instance.fadeInDuration;
        instance.image.enabled = true;
        instance.image.canvasRenderer.SetAlpha(0.0f);
		instance.image.CrossFadeAlpha(1.0f, concreteFadeInDuration, false);
		yield return new WaitForSeconds(concreteFadeInDuration);
    }

	public static IEnumerator FadeOutAsync(float fadeOutDuration = -1f)
    {
		float concreteFadeOutDuration = fadeOutDuration != -1f ? fadeOutDuration : instance.fadeOutDuration;
        instance.image.enabled = true;
        instance.image.canvasRenderer.SetAlpha(1.0f);
		instance.image.CrossFadeAlpha(0.0f, concreteFadeOutDuration, false);
		yield return new WaitForSeconds(concreteFadeOutDuration);
    }
}
