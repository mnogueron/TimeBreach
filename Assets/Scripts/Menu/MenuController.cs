using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public Button loadGameButton;
    
	void Start () {
        if (LoadSaveManager.IsSaveAvailable())
        {
            loadGameButton.gameObject.SetActive(true);
        }
        else
        {
            loadGameButton.gameObject.SetActive(false);
        }
	}
}
