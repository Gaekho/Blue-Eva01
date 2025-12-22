using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    private int _hour;
    private int _minute;
    public int Hour { get => _hour; }
    public int Minute { get => _minute; }

    public string GetTime()
    {
        return Hour.ToString("00") + ":" + Minute.ToString("00");
    }

    public void PauseTime()
    {

    }

    public void ResumeTime()
    {

    }

    public void SpendTime(int min)
    {

    }
    private TimeManager() { }
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Debug.Log("Time Manager Warning");
        
    }
    void Start()
    {
        _hour = 3;
        _minute = 30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
