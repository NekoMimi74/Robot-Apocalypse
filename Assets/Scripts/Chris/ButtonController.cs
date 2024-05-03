using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    SpriteRenderer sColor;
    public Boolean buttonCheck;
    public GameObject player;
    private playerControllerChris spawn;
    // Start is called before the first frame update
    void Start()
    {
        sColor = GetComponent<SpriteRenderer>();
        buttonCheck = false;
        spawn = player.GetComponent<playerControllerChris>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn.stageCount % 2 == 1)
        {
            buttonCheck = true;
        }
        if (!buttonCheck)
        {
            sColor.color = (Color)(new Color32(211, 134, 86, 255));
        }
    }

    public Boolean isButtonOn()
    {
        if (buttonCheck)
        {
            return true;
        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            sColor.color = (Color)(new Color32(0, 0, 0, 255));
            buttonCheck = true;
        }
    }
}
