using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public enum World { FUTURE, PRESENT };

    // only one instance of the GameManager can exist inside the game
    public static GameManager instance = null;

    public Camera mainCamera;
    public Camera secondCamera;
    public Player player;

    public World currentWorld = World.FUTURE;

	public LayerMask futureWorldLayer;
	public LayerMask presentWorldLayer;

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
            UIManager.DisplayOrbActivable();
            if (Input.GetButtonDown("Open/Close Gate"))
            {
				SwitchWorld ();
            }
        }
        else
        {
            UIManager.DisplayOrbNotActivable();
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

    /*
        Static functions
    */
    public static Player Player()
    {
        return instance.player;
    }

	public static LayerMask FutureWorldLayer(){
		return instance.futureWorldLayer;
	}

	public static LayerMask PresentWorldLayer(){
		return instance.presentWorldLayer;
	}

	public static void SwitchWorld(){
		instance.secondCameraEnable = !instance.secondCameraEnable;
		instance.secondCamera.enabled = instance.secondCameraEnable;
		instance.player.SwitchWorld();

        //Debug.Log("Switch World GameManager");

        switch (instance.currentWorld)
        {
            case World.FUTURE:
                instance.currentWorld = World.PRESENT;
                break;
            case World.PRESENT:
                instance.currentWorld = World.FUTURE;
                break;
        }

        instance.DisableCollisionForCurrentWorld();
    }

    public static bool IsWorldFuture()
    {
        return instance.currentWorld.CompareTo(World.FUTURE) == 0;
    }

    public static void AddKey()
    {
        instance.player.numberOfKey++;
        if(instance.player.numberOfKey == 1)
        {
            UIManager.DisplayKey();
        }
    }

    public static void RemoveKey()
    {
        instance.player.numberOfKey--;
        if (instance.player.numberOfKey == 0)
        {
            UIManager.HideKey();
        }
    }

    public static bool HasKey()
    {
        return instance.player.numberOfKey > 0;
    }
}
