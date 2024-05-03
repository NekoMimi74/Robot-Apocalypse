using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //kept old code and commented it out, put more comfy 2d movement-chris

    Rigidbody2D myBod;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float speed;
    public float jump;
    private Boolean isRight = true;
    private float horizontal;
    public int count = 0;
    public int HP;





    void Start()
    {
        myBod = GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            myBod.velocity = new Vector2(myBod.velocity.x, jump);
        }

        Flip();
    }

    void FixedUpdate()
    {
        myBod.velocity = new Vector2(horizontal * speed, myBod.velocity.y);
    }

    //Flips based on which way the character is moving based on input
    private void Flip()
    {
        if (isRight && horizontal < 0f || !isRight && horizontal > 0f)
        {
            isRight = !isRight;
            Vector2 direction = transform.localScale;
            direction.x *= -1f;
            transform.localScale = direction;
        }
    }

    //sets a check for if player is on ground by creating a check zone for invisible box that is child object of player
    private Boolean isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        // player hp countdown
        if (c.tag == "Enemy Bullet")
        {
            HP--;
            // Something should go here
        }


    }
}
/*
   Rigidbody2D myBod;
   public float speed;
   //added variable to tweak jump-Chris
   public float jump;

   // Start is called before the first frame update
   void Start()
   {
       myBod = GetComponent<Rigidbody2D>();

   }

   // Update is called once per frame
   void Update()
   {
       if (transform.position.y <= 1.1f)
       {
           // on ground
           myBod.drag = 5;
           float h = Input.GetAxis("Horizontal");
           float v = Input.GetAxis("Vertical");
           transform.position += h * Vector3.right * Time.deltaTime * speed;

           if (Input.GetButtonDown("Jump"))
           {
               myBod.AddForce(Vector3.up * 6, ForceMode2D.Impulse);
           }
       }
       else
       {
           //flying
           myBod.drag = 0;
       }
   }
   */




