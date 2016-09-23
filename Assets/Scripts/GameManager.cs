using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public enum World { FUTURE, PRESENT };

    public static GameManager instance = null;

    public Camera mainCamera;
    public Camera secondCamera;
    public Player player;

    public World currentWorld = World.FUTURE;

    private bool secondCameraEnable = false;

	// Use this for initialization
	void Awake () {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        mainCamera.enabled = true;
        secondCamera.enabled = false;

        DisableCollisionForCurrentWorld();
        DisableCollisionConstant();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (player.CanSwitchWorld())
        {
            UIManager.instance.DisplayOrbActivable();
            if (Input.GetKeyDown(KeyCode.C))
            {
                secondCameraEnable = !secondCameraEnable;
                secondCamera.enabled = secondCameraEnable;
                player.SwitchWorld();
            }
        }
        else
        {
            UIManager.instance.DisplayOrbNotActivable();
        }
    }

    public void DisableCollisionForCurrentWorld()
    {
        switch (currentWorld)
        {
            case World.FUTURE:
                DisableCollisionForFuture();
                break;
            case World.PRESENT:
                DisableCollisionForPresent();
                break;
        }
    }

    private void DisableCollisionConstant()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Items World Present"), LayerMask.NameToLayer("Items World Future"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("World Present"), LayerMask.NameToLayer("Items World Future"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("World Future"), LayerMask.NameToLayer("Items World Present"), true);
    }

    private void DisableCollisionForPresent()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Items World Future"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Items World Present"), false);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("World Future"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("World Present"), false);
    }

    private void DisableCollisionForFuture()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Items World Future"), false);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Items World Present"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("World Future"), false);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("World Present"), true);
    }
}
