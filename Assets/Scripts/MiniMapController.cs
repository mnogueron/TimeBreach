using UnityEngine;
using System.Collections;

public class MiniMapController : MonoBehaviour {

    // only one instance of the MiniMapController can exist inside the game
    public static MiniMapController instance = null;

    private class PowerBarListenerForMiniMap : PowerBarListener
    {
        public void OnStatusBarDepleted()
        {
            MiniMapController.HideMiniMap();
        }
    }

    public GameObject mask;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            instance.gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void DisplayMiniMap()
    {
        instance.mask.SetActive(false);
        instance.gameObject.SetActive(true);

        PowerBarManager.SetListener(new PowerBarListenerForMiniMap());
        PowerBarManager.StartDecrease(1f);
    }

    public static void HideMiniMap()
    {
        instance.mask.SetActive(true);
        instance.gameObject.SetActive(false);

        PowerBarManager.RemoveListener();
        PowerBarManager.StartRegen();
    }

    public static void SwitchMiniMapState()
    {
        if (instance.gameObject.activeSelf)
        {
            HideMiniMap();
        }
        else
        {
            DisplayMiniMap();
        }
    }
}
