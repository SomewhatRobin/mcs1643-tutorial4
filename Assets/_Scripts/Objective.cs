using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public Sprite ObjectiveCompleteSprite;
    public GameObject levelCompleteScreen;
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
        if (clear)
        {
            audioSrc.Play();
        }
     

        clear = true;
        //pop up the level 
        //btw order of Canvas rendering depends on order in hierarchy/editor. Lower stuff is on higher layer
        levelCompleteScreen.SetActive(true);
    }

}
