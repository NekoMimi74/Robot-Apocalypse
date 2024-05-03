using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHealth : MonoBehaviour
{
    public GameObject player;
    public GameObject healthText;
    private playerControllerChris playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<playerControllerChris>();
    }

    // Update is called once per frame
    void Update()
    {
        if (heartCheck)
        {
            healthText.SetActive(true);
            if (playerScript.crystalPoint >= 10 && Input.GetKeyDown("e"))
            {
                playerScript.health++;
                playerScript.shopPurchase(10);
            }
        }
        else
        {
            healthText.SetActive(false);
        }
    }
    //i put these here because i can sue me -chris
    public Boolean heartCheck;
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            if (gameObject.CompareTag("ShopHeart"))
            {
                heartCheck = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            if (gameObject.CompareTag("ShopHeart"))
            {
                heartCheck = false;
            }
        }
    }
}
