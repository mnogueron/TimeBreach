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
        HideKey();
	}
	
	// Update is called once per frame
	void Update () {}

    public static void DisplayOrbActivable()
    {
        instance.orbActivable.enabled = true;
        instance.orbNotActivable.enabled = false;
    }

    public static void DisplayOrbNotActivable()
    {
        instance.orbActivable.enabled = false;
        instance.orbNotActivable.enabled = true;
    }

    public static void DisplayKey()
    {
        instance.key.enabled = true;
    }

    public static void HideKey()
    {
        instance.key.enabled = false;
    }
}
