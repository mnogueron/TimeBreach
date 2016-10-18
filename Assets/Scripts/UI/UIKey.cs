using UnityEngine;
using System.Collections;

public class UIKey : MonoBehaviour {

    private RectTransform rectTransform;
    
	void Start () {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        //rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newY);
    }
}
