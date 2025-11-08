using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool _paused;
    public GameObject PauseMenu;


    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        _paused = false;
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
}
