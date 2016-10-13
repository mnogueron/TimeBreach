using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    // only one instance of the GameManager can exist inside the game
    public static GameManager instance = null;

    public bool isPaused = false;
    private bool pauseExited = false;

	// Use this for initialization
	void Awake () {
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
	
	// Update is called once per frame
	void LateUpdate () {
        if (Player.CanSwitchWorld())
        {
            if (!instance.isPaused)
            {
                if (Input.GetButtonDown("Open/Close Gate"))
                {
                    MiniMapController.HideMiniMap();
                    SwitchWorld();
                }
            }
        }

        if (WorldManager.IsWorldFuture() && Input.GetButtonDown("MiniMap"))
        {
            MiniMapController.SwitchMiniMapState();
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

        if (Input.GetKeyDown("v"))
        {
            Debug.Log("Start decrease");
            PowerBarManager.StartDecrease();
        }

        if (Input.GetKeyDown("b"))
        {
            Debug.Log("Start regen");
            PowerBarManager.StartRegen();
        }

        // delay next update by 1 frame to prevent from "jumping" with a controller 
        if (isPaused && pauseExited)
        {
            isPaused = false;
            pauseExited = false;
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
        GameManager.instance.pauseExited = true;
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
