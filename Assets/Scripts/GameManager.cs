using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

    // only one instance of the GameManager can exist inside the game
    public static GameManager instance = null;

    private class PowerBarListenerForSwitch : PowerBarListener
    {
        public void OnPowerBarEmpty()
        {
            if (Player.CanSwitchWorld())
            {
                GameManager.SwitchWorld();
            }
            else
            {
                UIPowerBar.BlockRegen();
            }
        }
    }

    public bool isPaused = false;

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

		if (!isPaused && Player.HasOrbem ())
        {

            if(Player.CanSwitchWorld() && UIPowerBar.IsEmpty() && !WorldManager.IsWorldFuture())
            {
                Player.SwitchWorld();
                WorldManager.SwitchWorld();
                UIPowerBar.StartRegen();
            }


            if (Input.GetButtonDown("Open/Close Gate") && Player.CanSwitchWorld() && !UIPowerBar.IsEmpty())
            {
                SwitchWorld();
            }

            if (WorldManager.IsWorldFuture() && Input.GetButtonDown("MiniMap") && !UIPowerBar.IsEmpty())
            {
                MiniMapController.SwitchMiniMapState();
            }

            if (Input.GetKeyDown("v"))
            {
                Debug.Log("Start decrease");
                UIPowerBar.StartDecrease(2f);
            }

            if (Input.GetKeyDown("b"))
            {
                Debug.Log("Start regen");
                UIPowerBar.StartRegen();
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

    /*public static bool IsOrbEnabled()
    {
        return instance.orbEnable;
    }*/

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
            MaskController.CloseGate();
            UIPowerBar.RemoveListener();
            UIPowerBar.StartRegen();
        }
        else
        {
            MaskController.OpenGate();
            UIPowerBar.SetListener(new PowerBarListenerForSwitch());
            UIPowerBar.StartDecrease(2f);
        }
    }
}
