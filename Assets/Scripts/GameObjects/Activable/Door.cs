﻿using UnityEngine;
using System.Collections;

public class Door : Activable {

    private GameObject buttonDisabledSign;
    private Animator animator;
    public AudioClip openDoor;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        buttonDisabledSign = button.transform.FindChild("Button").FindChild("DisabledSign").gameObject;
        buttonDisabledSign.SetActive(false);
    }

    // Update is called once per frame
    protected override void Update () {
        base.Update();
        if (button.activeSelf)
        {
            if (!Player.HasKey() && !buttonDisabledSign.activeSelf)
            {
                buttonDisabledSign.SetActive(true);
            }
            else if (Player.HasKey() && buttonDisabledSign.activeSelf)
            {
                buttonDisabledSign.SetActive(false);
            }
        }
    }

    protected override void Activate()
    {
        if (Player.HasKey())
        {
            GameManager.RemoveKey();
            //animator.SetTrigger("fadeOut");
            //buttonIsDisabled = true;
            //button.SetActive(false);

            PlayerData dataToSave = new PlayerData();
            dataToSave.isCheckpoint = false;
            dataToSave.sceneData = SceneLoader.GetNextSceneName();

            LoadSaveManager.Save(dataToSave);

            AudioSource.PlayClipAtPoint(openDoor, transform.position);
            SceneLoader.LoadNextScene();
        }
    }

    protected void Disable()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
