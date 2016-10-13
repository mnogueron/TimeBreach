using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerBarManager : MonoBehaviour {

    // only one instance of the PowerBarManager can exist inside the game
    public static PowerBarManager instance = null;

    public Image powerBar;
    public float minSize = 330f;
    public float speed = 0.1f;

    private bool isDecreasing = false;
    private bool isRegenerating = false;
    private float power = 100f;
    private float powerLoss = 1f;
    private float powerRegen = 5f;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log(powerBar.color);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        if (isDecreasing)
        {
            if(power > 0)
            {
                power -= powerLoss * speed;
                powerBar.rectTransform.offsetMax = new Vector2(-minSize + minSize * (power / 100f), powerBar.rectTransform.offsetMax.y);
                powerBar.color = new Color(1f, (power / 100f), (power / 100f), 1f);
            }
            else
            {
                isDecreasing = false;
            }
        }
        else if (isRegenerating)
        {
            if(power < 100)
            {
                power += powerRegen * speed;
                powerBar.rectTransform.offsetMax = new Vector2(-minSize + minSize * (power / 100f), powerBar.rectTransform.offsetMax.y);
                powerBar.color = new Color(1f, (power / 100f), (power / 100f), 1f);
            }
            else
            {
                isRegenerating = false;
            }
        }
	}

    public static void StartDecrease()
    {
        instance.isRegenerating = false;
        instance.isDecreasing = true;
    }

    public static void StartRegen()
    {
        instance.isDecreasing = false;
        instance.isRegenerating = true;
    }
}
