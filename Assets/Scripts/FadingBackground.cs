using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadingBackground : MonoBehaviour {

    public static FadingBackground instance;

    public Image image;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static IEnumerator FadeInAsync()
    {
        instance.image.canvasRenderer.SetAlpha(0.0f);
        instance.image.CrossFadeAlpha(1.0f, 1.5f, false);
        yield return null;
    }

    public static IEnumerator FadeOutAsync()
    {
        instance.image.canvasRenderer.SetAlpha(1.0f);
        instance.image.CrossFadeAlpha(0.0f, 1.5f, false);
        yield return null;
    }
}
