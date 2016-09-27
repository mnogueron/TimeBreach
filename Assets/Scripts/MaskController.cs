using UnityEngine;
using System.Collections;

public class MaskController : MonoBehaviour {

    public float amplitudeX = 0.1f;
    public float amplitudeY = 0.1f;
    public float omegaX = 8.0f;
    public float omegaY = 10.0f;

    public float baseScaleX = 8.0f;
    public float baseScaleY = 8.0f;

    private float index;

    // Update is called once per frame
    void Update()
    {
        if (WorldManager.instance.currentWorld.CompareTo(WorldManager.World.PRESENT) == 0)
        {
            index += Time.deltaTime;
            float x = baseScaleX + amplitudeX * Mathf.Cos(omegaX * index);
            float y = baseScaleY + amplitudeY * Mathf.Cos(omegaY * index);
            transform.localScale = new Vector3(x, 0, y);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(GameManager.Player().transform.position.x, GameManager.Player().transform.position.y, transform.position.z);
    }
}
