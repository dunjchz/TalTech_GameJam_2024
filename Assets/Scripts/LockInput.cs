using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockInput : MonoBehaviour
{
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    //public Text errorMessageText;

    private bool egg = false; // Variable to store the state of egg

    public void OnSubmitButtonPressed()
    {
        // Check if the input values match the desired values
        if (inputField1.text == "4" && inputField2.text == "2" && inputField3.text == "0")
        {
            egg = true; // Set egg variable to true if the code is correct
            Debug.Log("Code is correct, u have an egg!");
        }
        else
        {
            egg = false; // Set egg variable to false if the code is incorrect
            Debug.Log("Code is incorrect!");
            //errorMessageText.text = "Code incorrect"; // Display error message
        }
    }

    public bool GetEgg()
    {
        return egg;
    }
}
