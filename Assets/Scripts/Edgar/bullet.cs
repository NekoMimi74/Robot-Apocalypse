using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.right * speed * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Shootable")||c.CompareTag("Ground")||c.CompareTag("Wall")||c.CompareTag("Boom"))
        {
            Destroy(gameObject);
        }
    }
}
