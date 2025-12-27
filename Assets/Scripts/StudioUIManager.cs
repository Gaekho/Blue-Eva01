using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StudioUIManager : MonoBehaviour
{
    public int subscriber { get; private set; }
    public Text subscribertxt;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        subscriber = 25481;
        subscribertxt.text = CalcSub();
    }

    // Update is called once per frame

    public string CalcSub()
    {
        double temp;
        temp = (double) subscriber / 1000;
        Debug.Log(temp);
        return temp.ToString("N2") + "K";
    }

    public int UpdateSub(int change)
    {
        subscriber += change;
        return subscriber;
    }
    void Update()
    {

    }

    public void ApiRequest()
    {
        // Get it from TTS tester.
    }
}
