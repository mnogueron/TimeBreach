using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadingBackground : MonoBehaviour {

    public static FadingBackground instance;

    private Image image;

    public float fadeInDuration = 1.5f;
    public float fadeOutDuration = 1.5f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            image = GetComponent<Image>();
            image.enabled = false;
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

    public static IEnumerator FadeInAsync()
    {
        instance.image.enabled = true;
        instance.image.canvasRenderer.SetAlpha(0.0f);
        instance.image.CrossFadeAlpha(1.0f, instance.fadeInDuration, false);
        yield return new WaitForSeconds(instance.fadeInDuration);
    }

    public static IEnumerator FadeOutAsync()
    {
        instance.image.enabled = true;
        instance.image.canvasRenderer.SetAlpha(1.0f);
        instance.image.CrossFadeAlpha(0.0f, instance.fadeOutDuration, false);
        yield return new WaitForSeconds(instance.fadeOutDuration);
    }
}
