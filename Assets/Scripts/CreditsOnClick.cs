using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CreditsOnClick : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject buttonToSelect;

    public void OpenCredits()
    {
        eventSystem.SetSelectedGameObject(buttonToSelect);
    }
}
