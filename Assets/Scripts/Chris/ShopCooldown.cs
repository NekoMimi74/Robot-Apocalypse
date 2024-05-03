using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCooldown : MonoBehaviour
{
    public int cooldownCost = 25;
    public GameObject player;
    public GameObject cooldownText;
    private playerControllerChris playerScript;
    int cLimit = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<playerControllerChris>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownCheck)
        {
            if (cLimit < 3)
            {
                cooldownText.SetActive(true);
                cooldownText.GetComponent<TextMesh>().text = "Cooldown - " + cooldownCost;
                if (playerScript.crystalPoint >= cooldownCost && Input.GetKeyDown("e"))
                {
                    playerScript.bulletCooldownMax -= 0.25f;
                    playerScript.shopPurchase(cooldownCost);
                    cooldownCost += 25;
                    cLimit++;
                }
            }
            else
            {
                cooldownText.SetActive(false);
            }
        }
        else
        {
            cooldownText.SetActive(false);
        }
    }
    //i put these here because i can sue me -chris
    public Boolean cooldownCheck;
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            if (gameObject.CompareTag("ShopCooldown"))
            {
                cooldownCheck = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            if (gameObject.CompareTag("ShopCooldown"))
            {
                cooldownCheck = false;
            }
        }
    }
}
