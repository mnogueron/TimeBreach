using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour {

	private string loadLevel = "MainMenu";

	void Start()
	{
		LoadSaveManager.DeleteSave ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReturnToMainMenu(){
		StartCoroutine (ReturnToMainMenuAsync ());
	}

	public IEnumerator ReturnToMainMenuAsync(){
		yield return FadingBackground.FadeInAsync();
		SceneManager.LoadScene(loadLevel);
		yield return FadingBackground.FadeOutAsync();
		StartCoroutine(AudioSourceFader.instance.FadeInSound(10f));
	}
}
