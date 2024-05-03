using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class RobotBoom : MonoBehaviour
{
    public GameObject explosion;
    public float speed;

    private int x;

    Transform playerLocation;

    SpriteRenderer flipper; //Which way is the robot facing?
    public GameObject explosive;
    public int HP;
    public List<GameObject> itemList = new List<GameObject>();
    public int randomMax;
    public GameObject robot;
    private RobotController robotScript;

    // Start is called before the first frame update
    void Start()
    {
        robotScript = robot.GetComponent<RobotController>();
        playerLocation = GameObject.Find("Player").GetComponent<Transform>();

        flipper = GetComponent<SpriteRenderer>();

        velocitySet();
    }

    // Update is called once per frame
    public Vector3 test;
    void Update()
    {
        transform.position += new Vector3(x, 0, 0) * speed * Time.deltaTime;
        test = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // print("Boom!");
        if (other.tag == "Player")
        {
            GameObject g = Instantiate(explosion);
            g.transform.position = transform.position;

            Destroy(transform.gameObject);
        }

        if (other.tag == "Wall" || other.tag == "Button")
        {
            //flip the robot
            if (!flipper.flipX)
            {
                flipper.flipX = true;
            }
            else
            {
                flipper.flipX = false;
            }
            velocitySet();
        }
        if (other.tag == "Player Bullet")
        {
            HP -= robotScript.damage;

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
    private void OnCollisionEnter2D(Collision2D c)
    {
        //flip the robot
        if (c.gameObject.CompareTag("Shootable") || c.gameObject.CompareTag("Boom"))
        {
            if (!flipper.flipX)
            {
                flipper.flipX = true;
            }
            else
            {
                flipper.flipX = false;
            }
            velocitySet();
        }
        if (c.gameObject.CompareTag("Player"))
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

    void velocitySet()
    { // Set the velocity of the robot if targetPlayer is false
        if (!flipper.flipX)
        {
            x = -1;
        }
        else
        {
            x = 1;
        }
    }
}
