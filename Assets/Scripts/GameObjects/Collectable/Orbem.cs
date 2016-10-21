using UnityEngine;
using System.Collections;

public class Orbem : Collectable
{

    public AudioClip orbPickup;
    public Transform destination;

    protected override void PickUp()
    {
        AudioSource.PlayClipAtPoint(orbPickup, transform.position);
        gameObject.SetActive(false);
        Player.instance.transform.localPosition = destination.localPosition;
    }
}
