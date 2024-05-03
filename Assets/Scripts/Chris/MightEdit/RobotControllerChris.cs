using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RobotControllerChris : MonoBehaviour
{
    //Chris-EDITED FILE
    SpriteRenderer flipper;
    AudioSource laser;

    Transform playerLocation;

    public AudioClip clip;
    public GameObject projectile;
    public GameObject explosive; // Only on Robot Death
    public float sec; // How much secs between shots
    public float projectileSpeed;
    public float bulletStartX;
    public int startDelay; // Delay first shot at start of the game
    public int HP;

    private float timer;
    private int face; //use when robot is facing a different direction
    private float direction; //use when the robot is facing a different direction
    //ItemDrop Stuff
    public List<GameObject> itemList = new List<GameObject>();
    public int randomMax;

    // Start is called before the first frame update
    void Start()
    {
        flipper = GetComponent<SpriteRenderer>();
        laser = GetComponent<AudioSource>();

        playerLocation = GameObject.Find("Player").GetComponent<Transform>();

        facingDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            timer = sec;
            Shoot();
        }
        else
        {
            timer -= 1 * Time.deltaTime;
        }

        facingDirection();
    }

    void Shoot()
    {
        if (startDelay != 0)
        {
            startDelay--;
        }
        else
        {
            GameObject g = Instantiate(projectile);

            g.transform.position = new Vector2(transform.position.x + direction, transform.position.y);
            laser.PlayOneShot(clip);

            Rigidbody2D rb = g.AddComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.velocity = new Vector2(face, 0) * projectileSpeed * Time.deltaTime;
        }
    }

    void facingDirection()
    {
        float robot = transform.position.x;

        if (playerLocation.position.x < robot)
        {
            //print("Facing Left");
            flipper.flipX = true;
        }
        else
        {
            //print("Facing Right");
            flipper.flipX = false;
        }

        if (!flipper.flipX)
        {
            face = 1;
            direction = bulletStartX;
        }
        else
        {
            face = -1;
            direction = -bulletStartX;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player Bullet")
        {
            HP--;

            if (HP <= 0)
            {
                // Explosion
                GameObject g = Instantiate(explosive);
                g.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                //spawn loot on chance
                int i = UnityEngine.Random.Range(0, randomMax);
                if (i < itemList.Count)
                {
                    GameObject l = Instantiate(itemList[i]);
                    l.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                }
                Destroy(transform.gameObject);
            }
        }
    }
}
