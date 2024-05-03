using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform player;
    public Transform leftBound;
    public Transform rightBound;
    public float smoothDampTime = 0.15f;
    private float camWidth, camHeight;
    private float minX, maxX;
    private Vector3 smoothDampVelocity = Vector3.zero;
    float leftClamp, rightClamp;
    //move clamp
    public GameObject playerG;
    private playerControllerChris playerScript;
    //easier than doing something else
    int imDumb;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<playerControllerChris>();
        camHeight = Camera.main.orthographicSize * 2;
        camWidth = camHeight * Camera.main.aspect;
        leftClamp = leftBound.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
        minX = leftBound.position.x + leftClamp + (camWidth / 2);
        rightClamp = rightBound.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
        maxX = rightBound.position.x - rightClamp - (camWidth / 2);
        //for leftbound changes
        imDumb = 0;
    }

    // Update is called once per frame
    void Update()
    {
        minX = leftBound.position.x + leftClamp + (camWidth / 2);
        maxX = rightBound.position.x - rightClamp - (camWidth / 2);
        if (player)
        {
            float playerX = Mathf.Max(minX, Mathf.Min(maxX, player.position.x));
            float x = Mathf.SmoothDamp(transform.position.x, playerX, ref smoothDampVelocity.x, smoothDampTime);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
    }
    void FixedUpdate()
    {
        if (playerScript.stageCount == 1 && imDumb == 0)
        {
            imDumb++;
            rightBound.transform.position = rightBound.position + new Vector3(-27, 0, 0);
        }
        if (playerScript.stageCount == 2 && imDumb == 1)
        {
            imDumb++;
            rightBound.transform.position = rightBound.position + new Vector3(27 + (54.32f * 2), 0, 0);
        }
        if (playerScript.stageCount == 3 && imDumb == 2)
        {
            imDumb++;
            rightBound.transform.position = rightBound.position - new Vector3(27 + (54.32f * 2), 0, 0);
        }
        if (playerScript.stageCount == 4 && imDumb == 3)
        {
            rightBound.transform.position = rightBound.position + new Vector3(27 + (54.32f * 2), 0, 0);
            imDumb++;
        }
    }
}
