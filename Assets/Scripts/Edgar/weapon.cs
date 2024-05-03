using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
  public Transform firePoint;
  public GameObject Bullet; 
  playerController player;

    // Update is called once per frame
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<playerController>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
         Shoot();
        }
        
    }
    void Shoot()
    {
        //Shoting logic
        Instantiate(Bullet, firePoint.position, firePoint.rotation);
    }
}
