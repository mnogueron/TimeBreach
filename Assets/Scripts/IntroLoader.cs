using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IntroLoader : MonoBehaviour {

    public static IntroLoader instance;
    public int durationInSeconds;

    private List<Transform> listOfMessages;
    private int nbMessages;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            listOfMessages = new List<Transform>();
            nbMessages = transform.childCount;

            // add every children to the list of messages and start by deactivating them all
            for (int i = 0; i < nbMessages; i++)
            {
                listOfMessages.Add(transform.GetChild(i));
                listOfMessages[i].gameObject.SetActive(false);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(LoadIntroMessages());
    }

    public static IEnumerator LoadIntroMessages()
    {
        for (int i = 0; i < instance.nbMessages; i++)
        {
            // activate the message to display
            instance.listOfMessages[i].gameObject.SetActive(true);

            if (i != 0)
            {
                // fade out
                yield return FadingBackground.FadeOutAsync();
            }

            // wait for durationInSeconds seconds
            yield return new WaitForSeconds(instance.durationInSeconds);

            if (i < instance.nbMessages - 1)
            {
                // fade in
                yield return FadingBackground.FadeInAsync();

                // deactivate current message
                instance.listOfMessages[i].gameObject.SetActive(false);
            }
        }
        SceneLoader.LoadNextScene();
    }

}
