using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICollectable : MonoBehaviour {

    // only one instance of the UICollectable can exist inside the game
    public static UICollectable instance = null;

    public Image key;

	void Awake()
    {
        if (instance == null)
        {
            instance = this;
            key.enabled = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Show()
    {
        instance.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        instance.gameObject.SetActive(false);
    }

    public static void DisplayKey()
    {
        instance.key.enabled = true;
    }

    public static void HideKey()
    {
        instance.key.enabled = false;
    }

	public static void ChangeYPosition(float newY)
	{
		RectTransform rectTransform = instance.gameObject.GetComponent<RectTransform> ();
		rectTransform.anchoredPosition = new Vector2 (rectTransform.anchoredPosition.x, newY);
	}
}
