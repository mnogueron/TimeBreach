using UnityEngine;
using System.Collections;

public class LoadGameOnClick : MonoBehaviour {

	public void LoadGame()
    {
        PlayerData data = LoadSaveManager.Load();
        SceneLoader.LoadSceneByName(data.sceneData);
    }
}
