using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerBarManager : MonoBehaviour {

    // only one instance of the PowerBarManager can exist inside the game
    public static PowerBarManager instance = null;

    public Image powerBar;
    public Image orbActivable;
    public Image orbNonActivable;

    public float minSize = 330f;
    public float speed = 0.1f;

    private bool isDecreasing = false;
    private bool isRegenerating = false;
    private bool isDepleted = false;
    private bool isDisabled = false;

    private float power = 100f;
    private float powerLoss = 1f;
    private float powerRegen = 5f;

    private PowerBarListener listener;

    public static void SetListener(PowerBarListener listener)
    {
        instance.listener = listener;
    }

    public static void RemoveListener()
    {
        instance.listener = null;
    }

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            orbActivable.enabled = true;
            orbNonActivable.enabled = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {

        if (!GameManager.IsPaused())
        {
            if (isDecreasing)
            {
                if (power > 0)
                {
                    power -= powerLoss * speed;
                    powerBar.rectTransform.offsetMax = new Vector2(-minSize + minSize * (power / 100f), powerBar.rectTransform.offsetMax.y);
                    if (!isDisabled)
                    {
                        powerBar.color = new Color(1f, (power / 100f), (power / 100f), 1f);
                    }
                }
                else
                {
                    isDecreasing = false;
                    isRegenerating = true;
                    isDepleted = true;

                    ShowOrbNonActivable();

                    if (listener != null)
                    {
                        listener.OnStatusBarDepleted();
                    }
                }
            }
            else if (isRegenerating)
            {
                if (power < 100)
                {
                    power += powerRegen * speed;
                    powerBar.rectTransform.offsetMax = new Vector2(-minSize + minSize * (power / 100f), powerBar.rectTransform.offsetMax.y);
                    if (!isDisabled)
                    {
                        powerBar.color = new Color(1f, (power / 100f), (power / 100f), 1f);
                    }
                }
                else
                {
                    isRegenerating = false;
                    isDepleted = false;

                    if (!isDisabled)
                    {
                        ShowOrbActivable();
                    }
                }
            }
        }
	}

    private void ShowOrbActivable()
    {
        instance.orbActivable.enabled = true;
        instance.orbNonActivable.enabled = false;
    }

    private void ShowOrbNonActivable()
    {
        instance.orbActivable.enabled = false;
        instance.orbNonActivable.enabled = true;
    }

    public static void StartDecrease(float powerLoss)
    {
        instance.isRegenerating = false;
        instance.isDecreasing = true;
        instance.powerLoss = powerLoss;
    }

    public static void StartRegen()
    {
        instance.isDecreasing = false;
        instance.isRegenerating = true;
    }

    public static void BlockRegen()
    {
        instance.isRegenerating = false;
    }

    public static bool IsDepleted()
    {
        return instance.isDepleted;
    }

    public static void DisablePowerBar()
    {
        instance.isDisabled = true;
        instance.powerBar.color = new Color((1f / 255f) * 92f, (1f / 255f) * 92f, (1f / 255f) * 92f, (1f / 255f) * 200f);
        instance.ShowOrbNonActivable();
    }

    public static void EnablePowerBar()
    {
        instance.isDisabled = false;
        instance.powerBar.color = new Color(1f, 1f, 1f);
        if (!IsDepleted())
        {
            instance.ShowOrbActivable();
        }
    }
}
