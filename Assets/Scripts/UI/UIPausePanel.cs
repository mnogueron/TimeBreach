using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIPausePanel : MonoBehaviour {

    public static UIPausePanel instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void LoadLastCheckpoint()
    {
        Resume();
        StartCoroutine(SceneController.ResetScene());
    }

    public void Resume()
    {
        UIManager.HidePauseMenu();
        GameManager.Resume();
    }

    public void ReturnToMainMenu()
    {
        GameManager.Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
