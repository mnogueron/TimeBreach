using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public static UIManager instance = null;

    public Image orbActivable;
    public Image orbNotActivable;
    public Image key;
    public GameObject pauseMenu;

	// Use this for initialization
	void Awake () {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitialiseUI();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (Input.GetButtonDown("Pause"))
        {
            if (instance.pauseMenu.activeSelf)
            {
                GameManager.Resume();
                HidePauseMenu();
            }
            else
            {
                GameManager.Pause();
                DisplayPauseMenu();
            }
        }
    }

    private void InitialiseUI()
    {
        DisplayOrbActivable();
        HideKey();
    }

    public static void DisplayOrbActivable()
    {
        instance.orbActivable.enabled = true;
        instance.orbNotActivable.enabled = false;
    }

    public static void DisplayOrbNotActivable()
    {
        instance.orbActivable.enabled = false;
        instance.orbNotActivable.enabled = true;
    }

    public static void DisplayKey()
    {
        instance.key.enabled = true;
    }

    public static void HideKey()
    {
        instance.key.enabled = false;
    }

    public static void DisplayPauseMenu()
    {
        instance.pauseMenu.SetActive(true);
    }

    public static void HidePauseMenu()
    {
        instance.pauseMenu.SetActive(false);
    }
}
