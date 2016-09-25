using UnityEngine;
using System.Collections;

public class Key : Collectable
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void PickUp()
    {
        GameManager.AddKey();
        gameObject.SetActive(false);
    }
}
