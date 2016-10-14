using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    // only one instance of the UIManager can exist inside the game
    public static UIManager instance = null;

    public enum OrbState { ACTIVABLE, NOTACTIVABLE };
    
    public Image key;
    public GameObject pauseMenu;

    private OrbState orbState;

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
        instance.orbState = OrbState.ACTIVABLE;
	}

    void FixedUpdate()
    {
        if (Player.CanSwitchWorld() && orbState.Equals(OrbState.NOTACTIVABLE))
        {
            orbState = OrbState.ACTIVABLE;
            PowerBarManager.EnablePowerBar();
        }
        else if(!Player.CanSwitchWorld() && orbState.Equals(OrbState.ACTIVABLE))
        {
            orbState = OrbState.NOTACTIVABLE;
            PowerBarManager.DisablePowerBar();
        }
    }

    private void InitialiseUI()
    {
        HideKey();
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
