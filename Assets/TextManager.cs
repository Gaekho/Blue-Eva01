using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public InputField InputField;

    public static string savedText;

    public void SaveText(string text)
    {
        savedText = InputField.text;
        Debug.Log("Text saved.");
    }
}
