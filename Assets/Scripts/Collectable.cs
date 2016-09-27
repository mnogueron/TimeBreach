﻿using UnityEngine;
using System.Collections;

public abstract class Collectable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUp();
        }
    }

    protected abstract void PickUp();

}