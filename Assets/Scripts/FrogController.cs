using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public AnimationCurve animationCurve;
    private Coroutine jumpCoroutine = null;

    public float jumpDistance = 3;
    public float jumpDuration = 0.5f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpCoroutine is null)
        {
            Vector2 direction = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            // Jump if there is any input
            if (direction.magnitude != 0)
            {
                jumpCoroutine = StartCoroutine(AnimateJump(direction, jumpDuration, jumpDistance));
            }
        }
    }

    IEnumerator AnimateJump(Vector2 direction, float duration, float distance)
    {
        float elapsed = 0f;
        while (elapsed <= duration)
        {
            elapsed += Time.deltaTime;
            float percent = Mathf.Clamp01(elapsed / duration);
            float curvePercent = animationCurve.Evaluate(percent);
            rb.velocity = direction.normalized * Mathf.LerpUnclamped(0, distance, curvePercent);

            yield return null;
        }
        rb.velocity = new(0, 0);
        jumpCoroutine = null;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");

        if (jumpCoroutine is not null)
        {
            StopCoroutine(jumpCoroutine);
            jumpCoroutine = null;
            rb.velocity = new(0, 0);
            Vector2 collisionPosition = new(
                collision.contacts[0].point.x,
                collision.contacts[0].point.y);
            var direction = rb.position - collisionPosition;
            jumpCoroutine = StartCoroutine(AnimateJump(direction, jumpDuration, jumpDistance / 2));
        }
    }
}
