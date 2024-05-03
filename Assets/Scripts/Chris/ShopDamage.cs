using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDamage : MonoBehaviour
{
    public int damageCost = 50;
    public GameObject player;
    public GameObject damageText;
    private playerControllerChris playerScript;
    int dlimit = 0;
    public GameObject robot;
    private RobotController robotScript;
    // Start is called before the first frame update
    void Start()
    {
        robotScript = robot.GetComponent<RobotController>();
        playerScript = player.GetComponent<playerControllerChris>();
        robotScript.damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (damageCheck)
        {
            if (dlimit < 3)
            {
                damageText.SetActive(true);
                damageText.GetComponent<TextMesh>().text = "Damage - " + damageCost;
                if (playerScript.crystalPoint >= damageCost && Input.GetKeyDown("e"))
                {
                    playerScript.bulletDamage++;
                    robotScript.damage++;
                    playerScript.shopPurchase(damageCost);
                    damageCost += 50;
                    dlimit++;
                }
            }
            else
            {
                damageText.SetActive(false);
            }
        }
        else
        {
            damageText.SetActive(false);
        }
    }
    //i put these here because i can sue me -chris
    public Boolean damageCheck;
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            if (gameObject.CompareTag("ShopDamage"))
            {
                damageCheck = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            if (gameObject.CompareTag("ShopDamage"))
            {
                damageCheck = false;
            }
        }
    }
}
