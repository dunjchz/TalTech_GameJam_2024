using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Transform transitionPoint; // Specific point in the next scene where the player will appear

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the collider is the player
        {
            // Load the next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            // Teleport the player to the specified transition point in the next scene
            if (transitionPoint != null)
            {
                other.transform.position = transitionPoint.position;
            }
        }
    }
}

