using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Johny: change "public class NewBehaviourScript : MonoBehaviour" to "public class Health : MonoBehaviour"
public class Health : MonoBehaviour
{
    public Image myImage1;
    public Image myImage2;
    public Image myImage3;
    playerController player;
    // public int health;
    // public int numOfHearts;
    // public Image[] hearts;
    // public Sprite fullHeart;
    // public Sprite emptyHeart;
    // public PlayerHealth playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {

        //     health = playerHealth.health;
        //     numOfHearts = playerHealth.maxHealth;
        //     if (health > numOfHearts)
        //     {
        //         health = numOfHearts;
        //     }
        //     for (int i = 0; i < hearts.Length; i++)
        //     {
        //         if (i < health)
        //         {
        //             hearts[i].sprite = fullHeart;
        //         }
        //         else
        //         {
        //             hearts[i].sprite = emptyHeart;

        //         }
        //         if (i < numOfHearts)
        //         {
        //             hearts[i].enabled = true;
        //         }
        //         else
        //         {
        //             hearts[i].enabled = false;
        //         }
        //     }
        // }

        // void OnTriggerEnter2D(Collider2D col){

        //      }
        updateHP();
    }
    void updateHP()
    {
        if (player.HP == 3)
        {
            myImage3.enabled = true;
            myImage1.enabled = true;
            myImage2.enabled = true;
        }
        else if (player.HP == 2)
        {
            myImage3.enabled = false;
            myImage2.enabled = true;
            myImage1.enabled = true;
        }
        else if (player.HP == 1)
        {
            myImage3.enabled = false;
            myImage2.enabled = false;
            myImage1.enabled = true;
        }
        else if (player.HP == 0)
        {
            myImage1.enabled = false;
        }
    }

}
