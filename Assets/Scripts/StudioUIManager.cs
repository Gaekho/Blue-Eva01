using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudioUIManager : MonoBehaviour
{
    public int subscriber { get; private set; }
    private Text subscribertxt;
    public InputField articleField;

    // Start is called before the first frame update
    void Start()
    {
        subscriber = 225489;
        Debug.Log(CalcSub());
    }

    // Update is called once per frame

    public string CalcSub()
    {
        float temp;
        temp = subscriber / 1000;
        return temp.ToString("F2") + "K";
    }
    void Update()
    {
        
    }

    public void ApiRequest()
    {
        // Get it from TTS tester.
    }
}
