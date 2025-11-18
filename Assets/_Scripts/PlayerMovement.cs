using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 12.0f;
    public float enBumpForce = 3.0f;
    public BoxCollider2D groundCollider;

    private Rigidbody2D rb;
    private const float gravity = 2.0f;

    // Improvements to consider:
    // - Double jump
    // - Easing into movement (accelerating more slowly)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            //Remove one life
            GameManager.SubtractLife();

            //Bounce back player - from pinball Bumper.cs
            Vector2 myCenter = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            //Takes the center, //removes y difference, creates vector of differnce between contact point and object's center
            //myCenter.y = contactPoint.y;
            Vector2 forceVector = contactPoint - myCenter;

            //Tells the object in script what other object hit that in-script object
            //GameObject.ball = collision.gameObject;

            Rigidbody2D rb2 = collision.rigidbody;
            rb2.AddForce(forceVector * enBumpForce, ForceMode2D.Impulse);


        }
    }

    private bool IsGrounded()
    {
         return groundCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}
