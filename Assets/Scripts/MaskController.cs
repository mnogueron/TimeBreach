using UnityEngine;
using System.Collections;

public class MaskController : MonoBehaviour {

    public static MaskController instance;

    public float amplitudeX = 0.1f;
    public float amplitudeY = 0.1f;
    public float omegaX = 8.0f;
    public float omegaY = 10.0f;

    public float baseScaleX = 8.0f;
    public float baseScaleY = 8.0f;

    public float openSpeed = 2.0f;
    public float closeSpeed = 4.0f;

    public Vector3 currentScale;

    public bool isInAnimation = false;

    private bool opening = false;
    private Vector3 baseScale;
    private float index;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            baseScale = transform.localScale;

            // by default set to minimum
            transform.localScale = new Vector3(1f, 0f, 1f);
        }
        else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!WorldManager.IsWorldFuture())
        {
            index += Time.deltaTime;
            Vector3 newScale = new Vector3(currentScale.x + amplitudeX * Mathf.Cos(omegaX * index), 0f, currentScale.z + amplitudeY * Mathf.Cos(omegaY * index));
            transform.localScale = newScale;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Player.instance.transform.position.x, Player.instance.transform.position.y, transform.position.z);
    }

    public IEnumerator CloseGateAsync()
    {
        isInAnimation = true;
        while (currentScale.x > 5f || currentScale.z > 5f)
        {
            currentScale -= new Vector3(1f * closeSpeed, 0f, 1f * closeSpeed);
            yield return null;
        }
        isInAnimation = false;
    }

    public IEnumerator OpenGateAsync()
    {
        isInAnimation = true;
        transform.localScale = new Vector3(1f, 0f, 1f);
        while (currentScale.x < baseScale.x || currentScale.z < baseScale.z)
        {
            currentScale += new Vector3(1f * openSpeed, 0f, 1f * openSpeed);
            yield return null;
        }
        isInAnimation = false;
    }

    public static bool CanBeOpenedOrClosed()
    {
        return !instance.isInAnimation;
    }
}
