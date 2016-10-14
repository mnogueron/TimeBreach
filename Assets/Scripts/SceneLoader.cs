using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public static SceneLoader instance;

    public string currentScene = "SceneLoader";
    public string loadingScene = "Loader";

    private float minDuration = 3f;

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
        instance.StartCoroutine(LoadScene("Level1Test"));
    }


    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    static IEnumerator LoadScene(string sceneName)
    {
        // Fade to black
        yield return FadingBackground.FadeInAsync();

        // Load loading screen
        yield return SceneManager.LoadSceneAsync(instance.loadingScene);

        Debug.Log("Loading screen loaded");

        // !!! unload old screen (automatic)

        // Fade to loading screen
        //yield return instance.StartCoroutine(FadingBackground.FadeOutAsync());

        float endTime = Time.time + instance.minDuration;

        // Load level async

        // good way to load with loading screen
        //yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        if (Time.time < endTime)
        {
            yield return new WaitForSeconds(endTime - Time.time);
        }

        yield return FadingBackground.FadeInAsync();

        async.allowSceneActivation = true;

        // Load appropriate zone's music based on zone data
        //MusicManager.PlayMusic(music);

        // Fade to black
        //yield return instance.StartCoroutine(FadingBackground.FadeInAsync());

        // !!! unload loading screen
        //SceneManager.UnloadScene(instance.loadingScene);
        //LoadingSceneManager.UnloadLoadingScene();

        // Fade to new screen
        //yield return instance.StartCoroutine(FadingBackground.FadeOutAsync());

    }
}
