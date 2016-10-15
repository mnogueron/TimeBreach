using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

    // only one instance of the GameManager can exist inside the game
    public static GameManager instance = null;

    private class PowerBarListenerForSwitch : PowerBarListener
    {
        public void OnStatusBarDepleted()
        {
            if (Player.CanSwitchWorld())
            {
                GameManager.SwitchWorld();
            }
            else
            {
                PowerBarManager.BlockRegen();
            }
        }
    }

    public bool isPaused = false;
    public bool orbEnable = true;

    private bool pauseExited = false;

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

        if (!isPaused && orbEnable)
        {

            if(Player.CanSwitchWorld() && PowerBarManager.IsDepleted() && !WorldManager.IsWorldFuture())
            {
                Player.SwitchWorld();
                WorldManager.SwitchWorld();
                PowerBarManager.StartRegen();
            }


            if (Input.GetButtonDown("Open/Close Gate") && Player.CanSwitchWorld() && !PowerBarManager.IsDepleted())
            {
                SwitchWorld();
            }

            if (WorldManager.IsWorldFuture() && Input.GetButtonDown("MiniMap") && !PowerBarManager.IsDepleted())
            {
                MiniMapController.SwitchMiniMapState();
            }

            if (Input.GetKeyDown("v"))
            {
                Debug.Log("Start decrease");
                PowerBarManager.StartDecrease(2f);
            }

            if (Input.GetKeyDown("b"))
            {
                Debug.Log("Start regen");
                PowerBarManager.StartRegen();
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

    public static bool IsOrbEnabled()
    {
        return instance.orbEnable;
    }

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
        MiniMapController.HideMiniMap();

        Player.SwitchWorld();
        WorldManager.SwitchWorld();

        if (WorldManager.IsWorldFuture())
        {
            PowerBarManager.RemoveListener();
            PowerBarManager.StartRegen();
        }
        else
        {
            PowerBarManager.SetListener(new PowerBarListenerForSwitch());
            PowerBarManager.StartDecrease(2f);
        }
    }
}
