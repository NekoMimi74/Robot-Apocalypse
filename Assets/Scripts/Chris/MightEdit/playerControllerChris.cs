using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class playerControllerChris : MonoBehaviour
{
    //Chris-EDITED FILE
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
    public int health;
    Text heartPoints;
    Text crystalPoints;
    public int crystalPoint;
    Transform firePoint;
    public Vector3 spawnPoint;
    //weapon stuff
    public GameObject bullet;
    public float bulletSpeed;
    public Vector3 bulletDirection;
    public float bulletCooldown;
    public float bulletCooldownMax;
    //stage movement
    public List<GameObject> stageList = new List<GameObject>();
    public int stageCount;
    public int bulletDamage;
    Boolean gameOver;
    Text gameO;
    public GameObject robot;
    private RobotController playerDamage;
    public float moveForce;

    void Start()
    {
        playerDamage = robot.GetComponent<RobotController>();
        gameO = GameObject.Find("gameOver").GetComponent<Text>();
        gameO.text = "";
        myBod = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        numJumps = 0;
        crystalPoints = GameObject.Find("Points").GetComponent<Text>();
        heartPoints = GameObject.Find("HeartNum").GetComponent<Text>();
        firePoint = GameObject.Find("firePoint").GetComponent<Transform>();
        bulletDirection = new Vector3(bulletSpeed, 0, 0);
        spawnPoint = transform.position;
        bulletDamage = 1;
        //stage stuff
        stageCount = 0;
        for (int i = 0; i < stageList.Count; i++)
        {
            stageList[i].SetActive(false);
        }
        stageList[stageCount].SetActive(true);
    }

    void Update()
    {
        playerDamage.damage = bulletDamage;
        if (!gameOver)
        {
            crystalPoints.text = "" + crystalPoint;
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

            myBod.velocity = v;

            // facing left or right
            if (h < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                bulletDirection = new Vector3(-bulletSpeed, 0, 0);
            }
            else if (h > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                bulletDirection = new Vector3(bulletSpeed, 0, 0);
            }
            myAnim.SetBool("RUN", h != 0);
            //shoot
            if (Input.GetButtonDown("Fire1") && bulletCooldown <= 0)
            {
                bulletCooldown = bulletCooldownMax;
                GameObject b = Instantiate(bullet, firePoint.position, firePoint.rotation);
                Vector3 bV = bulletDirection;
                b.GetComponent<Rigidbody2D>().AddForce(bV);
                //myAnim.SetBool("SHOOT", true);
            }
            if (bulletCooldown > 0)
            {
                bulletCooldown -= Time.deltaTime;
            }
            stageList[stageCount].SetActive(true);
        }
        else
        {
            gameO.text = "Game Over";
        }
    }

    void FixedUpdate()
    {
        stageList[stageCount].SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        // player hp countdown
        if (c.tag == "Enemy Bullet")
        {
            health--;
            heartPoints.text = "" + health;
            if (health <= 0)
            {
                gameOver = true;
            }
        }
        if (c.tag == "Powerful")
        {
            health-=2;
            heartPoints.text = "" + health;
            if (health <= 0)
            {
                gameOver = true;
            }
        }
        //jumpcheck
        if (c.CompareTag("Ground") || c.CompareTag("Button")|| c.CompareTag("Wall"))
        {
            numJumps = maxJumps;
        }
        //item check
        if (c.CompareTag("Crystal"))
        {
            crystalPoint++;
        }
        if (c.CompareTag("BigCrystal"))
        {
            crystalPoint += 10;
        }
        if (c.CompareTag("Heart"))
        {
            health++;
        }
        if (c.CompareTag("Fall"))
        {
            transform.position = spawnPoint;
            health--;
            heartPoints.text = "" + health;
            if (health <= 0)
            {
                gameOver = true;
                gameObject.GetComponent<SpriteRenderer> ().enabled = false;
            }
        }
        if(c.CompareTag("Boss"))
        {
            myBod.AddForce(transform.right * moveForce + transform.up * moveForce);
        }
        if(c.CompareTag("Win"))
        {
            gameO.text = "You Win, I Guess";
        }
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        //hurt by bullet
        if (c.gameObject.tag == "Enemy Bullet" || c.gameObject.tag == "Shootable")
        {
            health--;
            heartPoints.text = "" + health;
            if (health <= 0)
            {
                gameOver = true;
                gameObject.GetComponent<SpriteRenderer> ().enabled = false;
            }
        }
        if (c.gameObject.tag == "Boom")
        {
            health -= 2;
            heartPoints.text = "" + health;
            if (health <= 0)
            {
                gameOver = true;
                gameObject.GetComponent<SpriteRenderer> ().enabled = false;
            }
        }
    }
    public void shopPurchase(int i)
    {
        crystalPoint = crystalPoint - i;
    }
    public int getDamage()
    {
        return bulletDamage;
    }

}