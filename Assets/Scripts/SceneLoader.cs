using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour {

    public static SceneLoader instance;
    
    public string loadingScene = "Loader";

    private List<string> listOfLevels;

    private float minDuration = 3f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            listOfLevels = new List<string>();
            listOfLevels.Add("TimeBreachMainMenu");
            listOfLevels.Add("Introduction");
            listOfLevels.Add("Level1Test");
            listOfLevels.Add("Level2");
            listOfLevels.Add("Level3");
            listOfLevels.Add("TimeBreach");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void LoadNextScene()
    {
        instance.StartCoroutine(LoadScene(GetNextSceneName()));
    }

    public static string GetNextSceneName()
    {
        int indexOfCurrentScene = instance.listOfLevels.IndexOf(SceneManager.GetActiveScene().name);
        string nextScene;
        if (indexOfCurrentScene + 1 >= instance.listOfLevels.Count)
        {
            nextScene = instance.listOfLevels[0];
        }
        else
        {
            nextScene = instance.listOfLevels[indexOfCurrentScene + 1];
        }
        return nextScene;
    }

    public static void LoadSceneByName(string sceneName)
    {
        instance.StartCoroutine(LoadScene(sceneName));
    }


    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    public static IEnumerator LoadScene(string sceneName)
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
