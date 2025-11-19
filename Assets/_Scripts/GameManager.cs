using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool _paused;
    public GameObject PauseMenu;
    public static int lives = 2;
    public static int Score = 0;
    public static bool _gameOver = false;

    public static int livesPerGame = 5;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_paused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
                _paused = true;
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
                _paused = false;
            }
        }
        
    }

    public static void StartGame()
    {
        Score = 0;
        lives = livesPerGame;
        _gameOver = false;
        _paused = false;
    }

    public static void SubtractLife() //static methods can only mess with static variables
    {
        lives--;
        Debug.Log($"Hit Enemy! Lives Left: {lives}");

        if (lives == 0)
        {
            //Game Over
            _gameOver = true;
            Debug.Log("Game Over!");
        }


    }
}
