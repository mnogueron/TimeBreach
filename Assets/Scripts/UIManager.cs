using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public static UIManager instance = null;

    public Image orbActivable;
    public Image orbNotActivable;
    public Image key;

	// Use this for initialization
	void Awake () {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DisplayOrbActivable();
        key.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DisplayOrbActivable()
    {
        orbActivable.enabled = true;
        orbNotActivable.enabled = false;
    }

    public void DisplayOrbNotActivable()
    {
        orbActivable.enabled = false;
        orbNotActivable.enabled = true;
    }
}
