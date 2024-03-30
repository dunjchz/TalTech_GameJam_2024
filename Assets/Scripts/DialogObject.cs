using System.Collections;
using TMPro;
using UnityEngine;

public class DialogObject : MonoBehaviour
{
    public CanvasRenderer panel;
    public TMP_Text textDisplay;
    public string[] dialogTextLines;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        ResetDialog();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ContinueDialog();
        }
    }

    public void StartDialog()
    {
        Time.timeScale = 0f;
        panel.gameObject.SetActive(true);
        StartCoroutine(Typing());
    }

    public void ContinueDialog()
    {
        index += 1;

        if (index < dialogTextLines.Length)
        {
            StartCoroutine(Typing());
            //textDisplay.SetText(dialogTextLines[index]);
        }
        else
        {
            ResetDialog();
        }
    }

    IEnumerator Typing()
    {
        textDisplay.SetText("");
        foreach (char letter in dialogTextLines[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSecondsRealtime(0.02f);
        }
    }

    private void ResetDialog()
    {
        panel.gameObject.SetActive(false);
        index = 0;
        textDisplay.SetText("");
        Time.timeScale = 1f;
    }
}
