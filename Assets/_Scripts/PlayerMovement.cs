using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float deltaSpeed = 3.0f;
    public float jumpForce = 12.0f;
    public float enBumpForce = 3.0f;
    public BoxCollider2D groundCollider;

    public GameObject ears;
    public GameObject shout;

    private Rigidbody2D rb;
    private const float gravity = 2.0f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool idle, walking, jumping;

    private AudioSource audioSrc;
    private AudioSource audioSrc2;
    private AudioSource audioSrc3;

    // Improvements to consider:
    // - Double jump
    // - Easing into movement (accelerating more slowly)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
        animator = GetComponent<Animator>();
        idle = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumping = false;
        audioSrc = GetComponent<AudioSource>();
        audioSrc2 = ears.GetComponentInChildren<AudioSource>();
        audioSrc3 = shout.GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager._gameOver)  return;

        Vector3 vel = rb.velocity;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;

            if (vel.x > -1 * speed)
            {
                vel.x -= deltaSpeed * Time.deltaTime;
            }
            //transform.position += Vector3.left * speed * Time.deltaTime;

            if (!walking && !Input.GetKey(KeyCode.Space))
            {
                animator.Play("Walk");
                walking = true;
            }

            idle = false;
            if (!Input.GetKey(KeyCode.Space))
            {
                jumping = false;
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;

            if (vel.x < speed)
            {
                vel.x += deltaSpeed * Time.deltaTime;
            }


            if (!walking && !Input.GetKey(KeyCode.Space))
            {
                animator.Play("Walk");
                walking = true;
            }

            idle = false;

            if (!Input.GetKey(KeyCode.Space))
            {
                jumping = false;
            }

        }

        else
        {
          
            vel.x = 0;
            if (!idle && IsGrounded() && !jumping)
            {
                idle = true;
                animator.Play("Idle");
                walking = false;
            }
           
        }
            rb.velocity = vel;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            if (!jumping)
            {
                //Boing sound
                audioSrc.Play();
                animator.Play("Jump");
                jumping = true;
            }
            idle = false;
            walking = false;
        }

 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            
            //animator.Play("Idle");
        }

        if (collision.transform.CompareTag("Enemy"))
        {
            //Remove one life
            GameManager.SubtractLife();

            //Player hurt sound
            audioSrc3.Play();

            //Bounce back player - from pinball Bumper.cs
            Vector2 myCenter = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            //Takes the center, //removes y difference, creates vector of differnce between contact point and object's center
            myCenter.y = contactPoint.y;
            Vector2 forceVector =  myCenter - contactPoint;
            forceVector.y += 1;
            //Tells the object in script what other object hit that in-script object
            //GameObject.ball = collision.gameObject;

           //Rigidbody2D rb2 = collision.rigidbody;
            rb.AddForce(forceVector * enBumpForce, ForceMode2D.Impulse);


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            //add points for Enemy
            GameManager.Score += 100;
            Debug.Log($"Killed Enemy! Score is now {GameManager.Score}");

            //Player Stomp Sound
            audioSrc2.Play();
            //Destroy the enemy
            Destroy(collision.gameObject);

        }
    }

    private bool IsGrounded()
    {
         return groundCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}
