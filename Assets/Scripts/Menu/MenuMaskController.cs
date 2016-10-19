using UnityEngine;
using System.Collections;

public class MenuMaskController : MonoBehaviour {

    public float amplitudeX = 0.1f;
    public float amplitudeY = 0.1f;
    public float omegaX = 8.0f;
    public float omegaY = 10.0f;

    public Vector3 currentScale;
    private float index;

    // Use this for initialization
    void Start () {
	    currentScale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        index += Time.deltaTime;
        Vector3 newScale = new Vector3(currentScale.x + amplitudeX * Mathf.Cos(omegaX * index), 0f, currentScale.z + amplitudeY * Mathf.Cos(omegaY * index));
        transform.localScale = newScale;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(MenuPlayer.instance.transform.position.x, MenuPlayer.instance.transform.position.y, transform.position.z);
    }
}
