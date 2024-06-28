using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            pauseMenuUI.SetActive(true);
        }
        else
        {
            pauseMenuUI.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void Start()
    {
        Time.timeScale = 1f;
    }
    public void resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void quitMatch()
    {
        Time.timeScale = 0f;
        isPaused = false;
        SceneManager.LoadScene("Menu");
    }
}
