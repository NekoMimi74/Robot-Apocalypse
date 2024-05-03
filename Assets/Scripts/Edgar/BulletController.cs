using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletControllerChris : MonoBehaviour
{
    //Chris-Have not edited
    public float bulletTimer; // how long does the bullet stay until destroy
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += -transform.right * speed * Time.deltaTime;

        //Commented out changed to destroy on collision-Chris
        /*if (bulletTimer <= 0)
        {
            Destroy(transform.gameObject);
        }
        else
        {*/
            //also don't know what bulletTimer actually did besides that -chris
            bulletTimer -= 1 * Time.deltaTime;
        //}
    }

    //this is for 3d (i think) -chris
    /*
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(transform.gameObject);
    }
    */

    //this is for 2d -chris
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(transform.gameObject);
    }
}
