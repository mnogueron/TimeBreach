using UnityEngine;
using System.Collections;

public abstract class Activable : MonoBehaviour {

	public GameObject button;
	public Transform activableColliderCheck;
	public float minDistance = 0.9f;

    public float offsetX = 0f;
    public float offsetY = 0.65f;
    
    public float omegaY = 7.5f;
    public float amplitudeY = 0.05f;

    private float index;
    protected bool buttonIsDisabled = false;

    // Use this for initialization
    protected virtual void Start () {

	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        if (!buttonIsDisabled)
        {
            index += Time.deltaTime;
            float distance = Vector2.Distance(activableColliderCheck.position, GameManager.Player().transform.position);

            if (distance <= minDistance)
            {
                if (!button.activeSelf)
                {
                    button.SetActive(true);
                }
                float y = amplitudeY * Mathf.Cos(omegaY * index);
                button.transform.position = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY + y, transform.position.z);
            }
            else {
                if (button.activeSelf)
                {
                    button.SetActive(false);
                }
            }
        }
	}

	void LateUpdate(){
		// check E pressed down
		if(Input.GetButtonDown ("Action") && button.activeSelf){
			Activate ();
		}
	}

	protected abstract void Activate ();
}
