using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Transform transitionPoint; // Specific point in the next scene where the player will appear

    private LockInput lockInput;

    private void Start()
    {
        // Find and store the LockInput script reference
        lockInput = FindObjectOfType<LockInput>();
        if (lockInput == null)
        {
            Debug.LogError("LockInput script not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)

    {
        Debug.Log("LockInput reference: " + lockInput); // Check if lockInput is not null
        if (lockInput != null)
        {
            Debug.Log("Egg value: " + lockInput.GetEgg()); // Check the value returned by GetEgg()
        }
        else
        {
            Debug.LogError("LockInput reference is null.");
        }
        //if (other.CompareTag("Player"))
        //{
        //    // Check if the player is allowed to transition to the next scene based on the egg value
        //    if (lockInput != null && lockInput.GetEgg())
        //    {
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //        if (transitionPoint != null)
        //        {
        //            other.transform.position = transitionPoint.position;
        //        }
        //    }
        //    else
        //    {
        //        Debug.Log("Egg is false. Player cannot transition to the next scene.");
        //    }
        //}
    }
}

