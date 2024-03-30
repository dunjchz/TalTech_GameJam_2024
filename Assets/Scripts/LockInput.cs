using UnityEngine;
using TMPro;

public class LockInput : MonoBehaviour
{
    public SceneTransition sceneTransition;
    public EggSceneController eggSceneController;
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    //public Text errorMessageText;

    public void OnSubmitButtonPressed()
    {
        // Check if the input values match the desired values
        if (inputField1.text == "4" && inputField2.text == "2" && inputField3.text == "0")
        {
            Debug.Log("Code is correct, u have an egg!");
            sceneTransition.egg = true;
            eggSceneController.ClosePanel();
        }
        else
        {
            Debug.Log("Code is incorrect!");
            //errorMessageText.text = "Code incorrect"; // Display error message
        }
    }
}
