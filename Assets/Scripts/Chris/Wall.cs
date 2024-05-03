using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    AudioSource laser;
    public AudioClip clip;
    public GameObject explosive;
    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Boss"))
        {
            // Explosion
            Destroy(gameObject);
            GameObject g = Instantiate(explosive);
            g.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
