using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScreenScript : MonoBehaviour
{
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
}
