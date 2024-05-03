using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover1 : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed;
    private Vector3 currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        currentTarget = pointB;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toTarget = currentTarget - transform.position;
        Vector3 frameStep = toTarget.normalized * speed * Time.deltaTime;
        if (frameStep.magnitude > 0 && frameStep.magnitude < toTarget.magnitude)
        {
            transform.position += frameStep;
        }
        else
        {
            transform.position = currentTarget;//snap to Traget
            if (currentTarget == pointA)
            {
                currentTarget = pointB;
            }
            else
            {
                currentTarget = pointA;
            }
        }
    }
}
