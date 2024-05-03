using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    public GameObject button;
    public GameObject portal;
    public GameObject cameraObject;
    public Boolean portalReady;
    public GameObject player;
    private playerControllerChris spawn;
    private ButtonController buttonScript;
    // Start is called before the first frame update
    void Start()
    {
        spawn = player.GetComponent<playerControllerChris>();
        buttonScript = button.GetComponent<ButtonController>();
        portal.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (buttonScript.isButtonOn())
        {
            portalReady = true;
            portal.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (spawn.stageCount == 1 || spawn.stageCount == 3)
        {
            portalReady = true;
            portal.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player" && portalReady)
        {
            spawn.stageList[spawn.stageCount].SetActive(false);
            portal.GetComponent<SpriteRenderer>().enabled = false;
            portalReady = false;
            spawn.spawnPoint = spawn.spawnPoint + new Vector3(0, 40, 0);
            player.transform.position = spawn.spawnPoint;
            buttonScript.buttonCheck = false;
            cameraObject.transform.position = cameraObject.transform.position + new Vector3(0, 40, 0);
            spawn.stageCount++;
        }
    }
}
