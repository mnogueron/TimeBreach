using UnityEngine;
using System.Collections;

public class Orb : Collectable {

    public AudioClip orbPickup;
    public GameObject descriptionContainer;
    public Transform orbColliderCheck;
    public float minDistance;
    public bool orbIsInFutureWorld;

    // Use this for initialization
    void Start()
    {
        descriptionContainer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(orbColliderCheck.position, Player.instance.transform.position);

        // display the text only if the distance between the player and the sign
        // is small enough AND if the sign is in the same world as the Player
        if (distance < minDistance && areInSameWorld())
        {
            descriptionContainer.SetActive(true);
        }
        else if (distance >= minDistance || !areInSameWorld())
        {
            descriptionContainer.SetActive(false);
        }
    }

    // checks if the sign is in the current world
    private bool areInSameWorld()
    {
        return (orbIsInFutureWorld && WorldManager.IsWorldFuture());
    }

    protected override void PickUp()
	{
        AudioSource.PlayClipAtPoint(orbPickup, transform.position);
		Player.SetHasOrbem (true);
		UIManager.ShowPowerBar ();
        gameObject.SetActive(false);
        descriptionContainer.SetActive(false);
    }
}
