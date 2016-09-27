using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    // only one instance of the GameManager can exist inside the game
    public static GameManager instance = null;

    public bool isPaused = false;

	// Use this for initialization
	void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (Player.CanSwitchWorld())
        {
            if (!instance.isPaused)
            {
                if (Input.GetButtonDown("Open/Close Gate"))
                {
                    SwitchWorld();
                }
            }
        }


        if (Input.GetButtonDown("Pause"))
        {
            if (isPaused)
            {
                Resume();
                UIManager.HidePauseMenu();
            }
            else
            {
                Pause();
                UIManager.DisplayPauseMenu();
            }
        }
    }

    /*
        Static functions
    */

    public static bool IsPaused()
    {
        return instance.isPaused;
    }

    public static void Pause()
    {
        GameManager.instance.isPaused = true;
        Time.timeScale = 0;
    }

    public static void Resume()
    {
        GameManager.instance.isPaused = false;
        Time.timeScale = 1;
    }

    public static void AddKey()
    {
        Player.AddKey();
        if (Player.HasKey())
        {
            UIManager.DisplayKey();
        }
    }

    public static void RemoveKey()
    {
        Player.RemoveKey();
        if (!Player.HasKey())
        {
            UIManager.HideKey();
        }
    }

    public static void SwitchWorld()
    {
        Player.SwitchWorld();
        WorldManager.SwitchWorld();
    }
}
