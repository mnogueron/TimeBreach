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

    public Vector3 currentScale;

    private bool opening = false;
    private Vector3 baseScale;
    private float index;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            baseScale = transform.localScale;
        }
        else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (WorldManager.instance.currentWorld.CompareTo(WorldManager.World.PRESENT) == 0)
        {
            index += Time.deltaTime;
            if (opening && (currentScale.x < baseScale.x || currentScale.z < baseScale.z))
            {
                currentScale += new Vector3(1f * openSpeed, 0f, 1f * openSpeed);
            }
            else if (opening && currentScale.x >= baseScale.x && currentScale.z >= baseScale.z)
            {
                opening = false;
            }
            else
            {
                currentScale = new Vector3(baseScale.x + amplitudeX * Mathf.Cos(omegaX * index), 0f, baseScale.z + amplitudeY * Mathf.Cos(omegaY * index));
            }
            transform.localScale = currentScale;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Player.instance.transform.position.x, Player.instance.transform.position.y, transform.position.z);
    }

    public static void CloseGate()
    {
        instance.opening = false;
    }

    public static void OpenGate()
    {
        instance.opening = true;
        instance.currentScale = Vector3.zero;
    }
}
