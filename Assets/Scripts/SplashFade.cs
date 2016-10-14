using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashFade : MonoBehaviour {

    public Image splashImage;
    public Text splashMessage;
    public string loadLevel;

    IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);
        splashMessage.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(2.5f);
        FadeOut();

        if (FadingBackground.GetFadeInDuration() < 2.5f)
        {
            yield return new WaitForSeconds(2.5f - FadingBackground.GetFadeInDuration());
        }

        yield return FadingBackground.FadeInAsync();
        //yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(loadLevel);
    }

    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);
        splashMessage.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
        splashMessage.CrossFadeAlpha(0.0f, 2.5f, false);
    }

}
