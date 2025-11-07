using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public float speed = 3.0f;
    public float zDistance = 10.0f;
    public float allowableOffset = 3.0f;
    public Vector3 topLeft;
    public Vector3 botRight;
    public GameObject player;

    // Improvements to consider:
    // - Easing movement at start and end
    // - Catching up more quickly if player is too far from center


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + Vector3.back * zDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position + Vector3.back * zDistance) > allowableOffset)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position + Vector3.back * zDistance, speed * Time.deltaTime);
        }

        Vector3 pos = transform.position;

        if (pos.x < topLeft.x)
        { 
            pos.x = topLeft.x;
        }

        if (pos.y > topLeft.y)
        {
            pos.y = topLeft.y;
        }

        if (pos.x > botRight.x)
        {
            pos.x = botRight.x;
        }

        if (pos.y < botRight.y)
        {
            pos.y = botRight.y;
        }

        pos.z = player.transform.position.z - zDistance;

        transform.position = pos;

    }
}
