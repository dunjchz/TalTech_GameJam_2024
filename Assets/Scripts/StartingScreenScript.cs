using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScreenScript : MonoBehaviour
{
    public GameObject menuPanel;

    // Cache the screen bounds to avoid recalculating them every update
    private float screenWidth;
    private float screenHeight;

    private void Start()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;

        // Calculate and cache the screen bounds
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (IsGamePaused())
            {
                ResumeGame();
                print("Resuming game: " + Time.timeScale);
            }
            else
            {
                PauseGame();
                print("Pausing game: " + Time.timeScale);
            }
        }
    }

    public void PlayGame()
    {
        //Load next scene in the build level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        print("Game Exited");

        //Quit the application
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        menuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
    }

    // Function to check if the game is currently paused
    private bool IsGamePaused()
    {
        return Time.timeScale == 0f;
    }


}
