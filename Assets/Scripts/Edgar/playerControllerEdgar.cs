using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class playerControllerEdgar : MonoBehaviour
{
    //Chris-EDITED FILE
    //kept old code and commented it out, put more comfy 2d movement-chris

    //prob touched these idk what i did tho just copy and paste if errors occur -chris
    Rigidbody2D myBod;
    Animator myAnim;
    //basic movement
    public float speed;
    private float horizontal;
    public int HP;
    //jumping
    public float jump;//jump power
    public int maxJumps;
    public int numJumps;
    /*
    //health
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Image[] hearts;
    public int numHearts;
    */
    public int health;
    Text heartPoints;
    Text crystalPoints;
    int points;

    //prob touched these idk what i did tho just copy and paste if errors occur -chris

    void Start()
    {
        myBod = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        numJumps = 0;
        //fullHeart = GameObject.Find("Heart").GetComponent<Sprite>();
        crystalPoints = GameObject.Find("Points").GetComponent<Text>();
        heartPoints = GameObject.Find("HeartNum").GetComponent<Text>();
        //emptyHeart = GameObject.Find("EmptyHeart").GetComponent<Sprite>();
    }

    void Update()
    {
        //remember to uncoment next 2 lines
         crystalPoints.text = "" + points;
         heartPoints.text = "" + health;
        // Basic Movement
        float h = Input.GetAxis("Horizontal");
        Vector2 v = myBod.velocity;
        v.x = h * speed;

        //Jumping
        if (Input.GetButtonDown("Jump") && numJumps > 0)
        {
            v.y = jump;
            numJumps--;
        
        }
       
        myAnim.SetBool("SHOOT", Input.GetButtonDown("Fire1"));
        myAnim.SetBool("Jump", h != 0);
        myAnim.SetBool("RunShoot", Input.GetButtonDown("Fire1"));





        myBod.velocity = v;

        // facing left or right
        if (h < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (h > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        myAnim.SetBool("RUN", h != 0);
        /* none of this exists for now
        //health
        //dont work idk so ignore -chris(prob need to find demo code to fix maybe week9?)
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        //this works tho,still no visual change cuz of something -chris
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
        */

    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        // player hp countdown
        if (c.tag == "Enemy Bullet")
        {
            HP--;
            // Something should go here
            // No it shouldn't you silly goose
            // your enemy bullet doesn't even and shouldn't even have a trigger lol -chris
        }
        //new jump stuff-chris
        if (c.CompareTag("Ground"))
        {
            numJumps = maxJumps;
        }
        if (c.CompareTag("Crystal"))
        {
            points++;
        }
        //this is where the someething should go -chris
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Enemy Bullet")
        {
            health--;
        }
    }

}