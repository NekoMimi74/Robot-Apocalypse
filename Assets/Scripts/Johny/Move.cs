using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This is all it does
        Vector3 move = Vector3.right * speed * Time.deltaTime;
        transform.position += move;
    }
}