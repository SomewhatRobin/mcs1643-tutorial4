using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseFlag : MonoBehaviour
{
    public Sprite ObjectiveCompleteSprite;

    private AudioSource audioSrc;
    public bool clear;


    void Start()
    {
        clear = false;
        audioSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Change the sprite
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = ObjectiveCompleteSprite;
        //TODO: Play some sound/music
        if (!clear)
        {
            audioSrc.Play();
        }


        clear = true;


    }
}
