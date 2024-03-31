using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public float videoDuration;

    void Start()
    {
        StartCoroutine(EndVideo());
    }

    IEnumerator EndVideo()
    {
        yield return new WaitForSecondsRealtime(videoDuration);
        // Load the next scene when the video finishes playing
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
