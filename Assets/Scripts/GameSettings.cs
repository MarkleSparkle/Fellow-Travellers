using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameSettings : MonoBehaviour
{

    public GameObject countdown;
    public GameObject pauseMenuManager;
    public GameObject gameOverMenu;
    public angerBarManager angerBarManager;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject gameCanvas;
    public Sprite holoStarSprite;
    public GameObject levelDisplay;

    private Text countdownText;
    float period = 1f;
    private float nextActionTime;
    public int gameTime; //got from inspector

    private int level;
    private int[] maxAnger;
    private float startTime;
    private float currentTime;


    // Start is called before the first frame update
    void Start()
    {
        level = SaveSystem.LoadLevel();
        countdownText = countdown.gameObject.GetComponent<Text>();
        countdownText.text = gameTime.ToString();

        //Setting level text
        levelDisplay.gameObject.GetComponent<Text>().text = "Level "+level;

        maxAnger = new int[3];//one for each level
        maxAnger[0] = 1000;
        nextActionTime = 0.0f;
        currentTime = Time.deltaTime;
        Debug.Log("Level " + level);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime < gameTime) //during gameTime
        {
            countdownText.text = (gameTime-Math.Floor(currentTime)).ToString();
        }

        else if (currentTime >= gameTime) //if the gameTime is 0 seconds
            gameOver();
        if (0 >= angerBarManager.getAnger()) //if the anger bar has run out
            gameOver();
    }

    // Showing the Game Over Menu and displaying appropriate amount of stars
    private void gameOver()
    {
        pauseMenuManager.GetComponent<PauseMenuManager>().pause();
        gameOverMenu.SetActive(true);
        gameCanvas.SetActive(false);

        bool[] active = angerBarManager.GetComponent<angerBarManager>().areStarsActive();
        if (!active[0])//if the star is not active (from the game)
        {
            star1.transform.GetComponent<Image>().sprite = holoStarSprite;
        }
        if (!active[1])//if the star is not active (from the game)
        {
            star2.transform.GetComponent<Image>().sprite = holoStarSprite;
        }
        if (!active[2])//if the star is not active (from the game)
        {
            star3.transform.GetComponent<Image>().sprite = holoStarSprite;
        }
    }

    // Called when Next Level button is pressed
    public void nextLevel()
    {
        level = level + 1;
        SaveSystem.SaveLevel(level);
        loadLevel();
    }

    // Called when Restart Level button is pressed
    public void restart()
    {
        loadLevel();
    }

    // Called when Main Menu button is pressed
    public void mainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    // Cleaning up the level before the next level starts
    private void loadLevel()
    {
        gameOverMenu.SetActive(false);
        gameCanvas.SetActive(true);

        //TODO restart the game
        // (build all cars in a parent so we can clear children post-level easier)
        pauseMenuManager.GetComponent<PauseMenuManager>().resume();//setting timescale to normal
        currentTime = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public int getLevel()
    {
        return level;
    }

    public void resetLevel()
    {
        SaveSystem.SaveLevel(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
