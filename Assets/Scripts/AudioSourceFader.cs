using UnityEngine;
using System.Collections;

public class AudioSourceFader : MonoBehaviour {

    public static AudioSourceFader instance;
    public float maxVolume;

    private AudioSource source;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            source = GetComponent<AudioSource>();
        }
        else {
            Destroy(gameObject);
        }
    }

    public void SetAudioClip(AudioClip audioClip)
    {
        source.clip = audioClip;
    }

    public IEnumerator FadeOutSound(float fadeOutDuration)
    {
        while (source.volume > 0.01f)
        {
            source.volume -= Time.deltaTime / fadeOutDuration;
            yield return null;
        }
    }

    public IEnumerator FadeInSound(float fadeInDuration)
    {
        source.volume = 0f;
        while (source != null && source.volume < maxVolume)
        {
            source.volume += Time.deltaTime / fadeInDuration;
            yield return null;
        }
    }
}
