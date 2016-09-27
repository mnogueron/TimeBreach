using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {

    // only one instance of the WorldManager can exist inside the game
    public static WorldManager instance = null;

    public Camera mainCamera;
    public Camera secondCamera;

    public LayerMask futureWorldLayer;
    public LayerMask presentWorldLayer;

    public World currentWorld = World.FUTURE;

    private bool secondCameraEnable = false;

    public enum World { FUTURE, PRESENT };

    void Awake()
    {

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

    /*// Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}*/

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

    public static LayerMask FutureWorldLayer()
    {
        return instance.futureWorldLayer;
    }

    public static LayerMask PresentWorldLayer()
    {
        return instance.presentWorldLayer;
    }

    public static LayerMask GetOppositeLayerMask()
    {
        return (IsWorldFuture()) ? PresentWorldLayer() : FutureWorldLayer();
    }

    public static void SwitchWorld()
    {
        instance.secondCameraEnable = !instance.secondCameraEnable;
        instance.secondCamera.enabled = instance.secondCameraEnable;
        GameManager.Player().SwitchWorld();

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
}
