using UnityEngine;
using System.Collections;

public class UIKey : MonoBehaviour {

    private RectTransform rectTransform;

    public float offsetX = 0f;
    public float offsetY = 0f;

    public float omegaY = 7.5f;
    public float amplitudeY = 0.05f;

    private float index;

    void Start () {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        index += Time.deltaTime;
        float y = amplitudeY * Mathf.Cos(omegaY * index);
        rectTransform.anchoredPosition = new Vector2(0f, y);
    }
}
