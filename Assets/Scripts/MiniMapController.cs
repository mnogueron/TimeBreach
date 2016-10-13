using UnityEngine;
using System.Collections;

public class MiniMapController : MonoBehaviour {

    // only one instance of the GameManager can exist inside the game
    public static MiniMapController instance = null;

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
    }

    public static void HideMiniMap()
    {
        instance.mask.SetActive(true);
        instance.gameObject.SetActive(false);
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
