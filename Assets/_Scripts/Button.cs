using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool triggered = false;
    public Mover TriggeredObject;
    public Sprite PressedSprite;
    private AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (!TriggeredObject.Moving)
            {
                audioSrc.Play();
            }
            TriggeredObject.Moving = true;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sprite = PressedSprite;
                     
            
        }
    }
}
