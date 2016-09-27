using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    // only one instance of the GameManager can exist inside the game
    public static GameManager instance = null;

    public Player player;

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
        if (player.CanSwitchWorld())
        {
            UIManager.DisplayOrbActivable();
            if (!instance.isPaused)
            {
                if (Input.GetButtonDown("Open/Close Gate"))
                {
                    WorldManager.SwitchWorld();
                }
            }
        }
        else
        {
            UIManager.DisplayOrbNotActivable();
        }
    }

    /*
        Static functions
    */
    public static Player Player()
    {
        return instance.player;
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
        GameManager.instance.isPaused = false;
        Time.timeScale = 1;
    }

    public static void AddKey()
    {
        instance.player.numberOfKey++;
        if (instance.player.numberOfKey == 1)
        {
            UIManager.DisplayKey();
        }
    }

    public static void RemoveKey()
    {
        instance.player.numberOfKey--;
        if (instance.player.numberOfKey == 0)
        {
            UIManager.HideKey();
        }
    }

    public static bool HasKey()
    {
        return instance.player.numberOfKey > 0;
    }

}
