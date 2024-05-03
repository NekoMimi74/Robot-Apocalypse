using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBoomChris : MonoBehaviour
{
    //Chris-Have not edited
    public GameObject explosion;
    public float speed;

    private int x;

    Transform playerLocation;

    SpriteRenderer flipper; //Which way is the robot facing?
    
    // Start is called before the first frame update
    void Start()
    {
        playerLocation = GameObject.Find("Player").GetComponent<Transform>();

        flipper = GetComponent<SpriteRenderer>();

        velocitySet();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(x, 0, 0) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other){
        // print("Boom!");
        if(other.tag == "Player"){
            GameObject g = Instantiate(explosion);
            g.transform.position = transform.position;

            Destroy(transform.gameObject);
        }

        if(other.tag == "Wall"){ //flip the robot
            if(!flipper.flipX){
                flipper.flipX = true;
            } else {
                flipper.flipX = false;
            }

            velocitySet();
        }
    }

    void velocitySet(){ // Set the velocity of the robot if targetPlayer is false
        if(!flipper.flipX){
            x = -1;
        } else {
            x = 1;
        }
    }
}
