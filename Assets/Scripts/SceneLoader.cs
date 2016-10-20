using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class SceneLoader : MonoBehaviour {

    public static SceneLoader instance;
    
    public string loadingScene = "Loader";

    private List<SceneData> listOfLevels;

    private float minDuration = 3f;

    public string currentLoadingText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            listOfLevels = new List<SceneData>();
            listOfLevels.Add(new SceneData("MainMenu"));
            listOfLevels.Add(new SceneData("Introduction"));
            listOfLevels.Add(new SceneData("Level1"));
            listOfLevels.Add(new SceneData("Level2", "This world is full of hazards, don't forget to jump to pass over obstacles."));
            listOfLevels.Add(new SceneData("Level3", "You better keep an eye on your power bar. When it's empty you will be automatically teleported back..."));
            listOfLevels.Add(new SceneData("Level4", "You better keep an eye on your power bar. When it's empty you will be automatically teleported back..."));
            //listOfLevels.Add(new SceneData("LevelDebug"));
			listOfLevels.Add(new SceneData("EndCredits"));

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void LoadNextScene()
    {
        SceneData nextScene = GetNextSceneName();
        instance.currentLoadingText = nextScene.loadingText;
        instance.StartCoroutine(LoadScene(nextScene.name));
    }

    public static SceneData GetNextSceneName()
    {
        int indexOfCurrentScene = instance.listOfLevels.IndexOf(new SceneData(SceneManager.GetActiveScene().name));
        SceneData nextScene;
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

    public static void LoadSceneByName(SceneData sceneData)
    {
        instance.currentLoadingText = sceneData.loadingText;
        instance.StartCoroutine(LoadScene(sceneData.name));
    }


    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    public static IEnumerator LoadScene(string sceneName)
    {
        // Fade to black
        instance.StartCoroutine(AudioSourceFader.instance.FadeOutSound(1.5f));
        yield return FadingBackground.FadeInAsync();

        // Load loading screen
        yield return SceneManager.LoadSceneAsync(instance.loadingScene);

        Debug.Log("Loading screen loaded");

        // Fade to loading screen
        yield return FadingBackground.FadeOutAsync();

        float endTime = Time.time + instance.minDuration;

        // Load level async

        // good way to load with loading screen
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        if (Time.time < endTime)
        {
            yield return new WaitForSeconds(endTime - Time.time);
        }

        yield return FadingBackground.FadeInAsync();

        async.allowSceneActivation = true;

        yield return FadingBackground.FadeOutAsync();
        instance.StartCoroutine(AudioSourceFader.instance.FadeInSound(10f));
    }
}

[Serializable]
public class SceneData
{
    public string name;
    public string loadingText;

    public SceneData(string name, string loadingText = "")
    {
        this.name = name;
        this.loadingText = loadingText;
    }

    public override bool Equals(object obj)
    {
        SceneData sceneData = obj as SceneData;
        if (sceneData == null) return false;
        return name.Equals(sceneData.name);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}