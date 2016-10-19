using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    // only one instance of the UIManager can exist inside the game
    public static UIManager instance = null;

    public enum OrbState { ACTIVABLE, NOTACTIVABLE };
    
    public GameObject pauseMenu;

    private OrbState orbState;

	private bool initialization = true;

	// Use this for initialization
	void Awake () {
        if(instance == null)
        {
            instance = this;
            orbState = OrbState.ACTIVABLE;
        }
        else
        {
            Destroy(gameObject);
        }
	}

    void FixedUpdate()
    {

		if(initialization) {
            if (!UIPowerBar.IsVisible())
            {
                HidePowerBar();
            }
            HideKey();
            initialization = false;
        }

		if (Player.HasOrbem ())
        {
            if (Player.CanSwitchWorld() && orbState.Equals(OrbState.NOTACTIVABLE))
            {
                orbState = OrbState.ACTIVABLE;
                UIPowerBar.EnablePowerBar();
            }
            else if (!Player.CanSwitchWorld() && orbState.Equals(OrbState.ACTIVABLE))
            {
                orbState = OrbState.NOTACTIVABLE;
                UIPowerBar.DisablePowerBar();
            }
        }
    }

    public static void DisplayKey()
    {
        UICollectable.DisplayKey();
    }

    public static void HideKey()
    {
        UICollectable.HideKey();
    }

    public static void DisplayPauseMenu()
    {
        instance.pauseMenu.SetActive(true);
    }

    public static void HidePauseMenu()
    {
        instance.pauseMenu.SetActive(false);
    }

	public static void ShowPowerBar(){
		UIPowerBar.Show ();
		UICollectable.ChangeYPosition (-130f);
	}

	public static void HidePowerBar(){
		UIPowerBar.Hide ();
		UICollectable.ChangeYPosition (-40f);
	}
}
