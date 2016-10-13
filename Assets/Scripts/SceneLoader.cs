using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public static SceneLoader instance;

    public string currentScene = "SceneLoader";
    public string loadingScene = "Loader";

    public float minDuration = 5f;

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

    public static void LoadNextScene()
    {
        instance.StartCoroutine(LoadScene("TimeBreach"));
    }


    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    static IEnumerator LoadScene(string sceneName)
    {
        // Fade to black
        yield return instance.StartCoroutine(FadingBackground.FadeInAsync());

        // Load loading screen
        yield return SceneManager.LoadSceneAsync(instance.loadingScene);

        // !!! unload old screen (automatic)

        // Fade to loading screen
        yield return instance.StartCoroutine(FadingBackground.FadeOutAsync());

        float endTime = Time.time + instance.minDuration;

        // Load level async

        // good way to load with loading screen
        //yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync(sceneName);

        if (Time.time < endTime)

            yield return new WaitForSeconds(endTime - Time.time);

        // Load appropriate zone's music based on zone data
        //MusicManager.PlayMusic(music);

        // Fade to black
        yield return instance.StartCoroutine(FadingBackground.FadeInAsync());

        // !!! unload loading screen
        //LoadingSceneManager.UnloadLoadingScene();

        // Fade to new screen
        yield return instance.StartCoroutine(FadingBackground.FadeOutAsync());

    }
}
