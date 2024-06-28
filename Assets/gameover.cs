using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    public static bool gameIsOver = false;
    public GameObject gameOverUI;
    void Start()
    {
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (staticClass.player1Health<=0 || staticClass.player2Health <= 0)
        {
            gameOverUI.SetActive(true);
            //Time.timeScale = 0f;
        }
    }
}
