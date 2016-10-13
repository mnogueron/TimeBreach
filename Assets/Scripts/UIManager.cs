using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    // only one instance of the UIManager can exist inside the game
    public static UIManager instance = null;

    public enum OrbState { ACTIVABLE, NOTACTIVABLE };

    public Image orbActivable;
    public Image orbNotActivable;
    public Image key;
    public GameObject pauseMenu;

    private OrbState orbState;

	// Use this for initialization
	void Awake () {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
            DisplayOrbActivable();
        }
        else if(!Player.CanSwitchWorld() && orbState.Equals(OrbState.ACTIVABLE))
        {
            orbState = OrbState.NOTACTIVABLE;
            DisplayOrbNotActivable();
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
