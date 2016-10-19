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

            if(Player.CanSwitchWorld() && UIPowerBar.IsEmpty() && !WorldManager.IsWorldFuture() && MaskController.CanBeOpenedOrClosed())
            {
                StartCoroutine(TeleportToFuture());
            }


            if (Input.GetButtonDown("Open/Close Gate") && CanSwitchWorld())
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

    public void TeleportToPresent()
    {
        MiniMapController.HideMiniMap();
        Player.SwitchWorld();

        // UI
        UIPowerBar.SetListener(new PowerBarListenerForSwitch());
        UIPowerBar.StartDecrease(2f);

        // start opening the gate asynchronously
        Debug.Log("OpenGate Async");
        instance.StartCoroutine(MaskController.instance.OpenGateAsync());

        // display the second camera
        WorldManager.SwitchWorld();
    }

    public IEnumerator TeleportToFuture()
    {
        Player.SwitchWorld();

        //change the transparence of the ghost
        GhostPlayer.SetVisible();

        // close the gate
        yield return MaskController.instance.CloseGateAsync();

        // go back to transparent
        GhostPlayer.SetTranparent();

        // hide the second camera
        WorldManager.SwitchWorld();

        // UI
        UIPowerBar.RemoveListener();
        UIPowerBar.StartRegen();
    }

    public static void SwitchWorld()
    {
        if (WorldManager.IsWorldFuture())
        {
            instance.TeleportToPresent();
        }
        else
        {
            instance.StartCoroutine(instance.TeleportToFuture());
        }
    }

    public bool CanSwitchWorld()
    {
        return (Player.CanSwitchWorld() && !UIPowerBar.IsEmpty() && MaskController.CanBeOpenedOrClosed());
    }
}
