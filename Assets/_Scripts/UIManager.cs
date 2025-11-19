using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreboardTMP;
    public GameObject[] LifeToken;
    public GameObject GameOverScreen;

    private void Start()
    {
        GameOverScreen.SetActive(false);
    }


    void Update()
    {
        ScoreboardTMP.text = GameManager.Score.ToString();

        if (GameManager._gameOver)
        {
            LifeToken[0].SetActive(false);
            GameOverScreen.SetActive(true);
            return;
        }


        //if lives is 1, I need to show only LifeToken[0]
        //If lives is 3, I need to show LifeToken[0], [1], & [2]

        for (int i = 0; i < LifeToken.Length; i++)
        {
            LifeToken[i].SetActive(false);
        }

        for (int i = 0; i < GameManager.lives; i++)
        {
            LifeToken[i].SetActive(true);
        }

    }

}
