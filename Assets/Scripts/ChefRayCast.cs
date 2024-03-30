using UnityEngine;
using UnityEngine.SceneManagement;

public class ChefRayCast : MonoBehaviour
{
    private Vector2 rayDirection = Vector2.left;

    private Vector3 rayOffset = new(0, -0.2f, 0);

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayOffset, rayDirection);
        if (hit.collider)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("ray hit");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
