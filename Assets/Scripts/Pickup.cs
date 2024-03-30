using System.Collections;
using TMPro;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public CanvasRenderer panel;
    public TMP_Text textDisplay;

    public bool isPickedUp = false;
    public string pickupText;

    private bool isTyping = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ContinueDialog();
        }
    }

    public void TriggerPickup()
    {
        Time.timeScale = 0f;
        panel.gameObject.SetActive(true);
        StartCoroutine(Typing());
    }

    public void ContinueDialog()
    {
        if (isTyping) return;
        panel.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPickedUp = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    IEnumerator Typing()
    {
        isTyping = true;
        textDisplay.SetText("");
        foreach (char letter in pickupText.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSecondsRealtime(0.02f);
        }
        isTyping = false;
    }
}
