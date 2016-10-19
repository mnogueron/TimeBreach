using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    public AudioClip keyPickup;
    public AudioClip openDoor;
    public AudioClip menuTheme;
    public AudioClip introTheme;
    public AudioClip mainTheme;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
