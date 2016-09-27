using UnityEngine;
using System.Collections;

public class ResumeOnClick : MonoBehaviour {

    public GameObject panel;

	public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.isPaused = false;
    }
}
