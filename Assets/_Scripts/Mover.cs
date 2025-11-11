using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public bool Moving = false;
    public float MinDistance = 0.01f;
    public float Speed = 1.2f;

    private bool MovingToPointA = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Moving)
        {
            return;
        }

        CheckDirection();

        if (MovingToPointA)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, Speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, Speed * Time.deltaTime);
        }


    }

    private void CheckDirection()
    {
        if (MovingToPointA)
        {
            if (Vector2.Distance(transform.position, pointA.position) <= MinDistance)
            {
                MovingToPointA = false;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, pointB.position) <= MinDistance)
            {
                MovingToPointA = true;
            }
        }
    }



    //eof
}
