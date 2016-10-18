using UnityEngine;
using System.Collections;

public class MiniMapController : MonoBehaviour {

    // only one instance of the MiniMapController can exist inside the game
    public static MiniMapController instance = null;

    private class PowerBarListenerForMiniMap : PowerBarListener
    {
        public void OnPowerBarEmpty()
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

            // by default always disable the minimap
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

        // the minimap consume power, start depleting the power bar
        UIPowerBar.SetListener(new PowerBarListenerForMiniMap());
        UIPowerBar.StartDecrease(1f);
    }

    public static void HideMiniMap()
    {
        instance.mask.SetActive(true);
        instance.gameObject.SetActive(false);

        UIPowerBar.RemoveListener();
        UIPowerBar.StartRegen();
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
