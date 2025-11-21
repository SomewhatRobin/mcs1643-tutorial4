using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPit : MonoBehaviour
{
    //public Sprite ObjectiveCompleteSprite;

    private AudioSource audioSrc;



    void Start()
    {

        audioSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Change the sprite
        //SpriteRenderer sr = GetComponent<SpriteRenderer>();
       // sr.sprite = ObjectiveCompleteSprite;
        //TODO: Play some sound/music

            audioSrc.Play();
        




    }
}
