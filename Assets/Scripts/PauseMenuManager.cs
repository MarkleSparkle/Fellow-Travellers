using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{

    public static bool pausedGame = false;

    public GameObject pauseMenu;
    public GameObject characterScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausedGame)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pausedGame = false;
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pausedGame = true;
    }

    public void characters()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
        characterScreen.SetActive(true);
    }
}
