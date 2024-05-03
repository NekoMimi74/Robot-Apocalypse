using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionControllerChris : MonoBehaviour
{
    //Chris-Have not edited
    // Made to remove explosion clone to not take up too much space
    // Feel free to just this script for anything else

    public float time; // How long does the clone gameObject stay

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= 1 * Time.deltaTime;

        if(time <= 0){
            Destroy(transform.gameObject);
        }
    }
}
