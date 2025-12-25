using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    [Header("Time Setting")]
    [SerializeField] private float _realtimePerGame10Minute = 10f;

    [Header("Initial Time")]
    [SerializeField, Range(0,23)] private int _startHour = 9;
    [SerializeField, Range(0, 50)] private int _startMinute = 0;

    private int _hour;
    private int _minute;
    private float _realAccum;
    public bool isRunning { get; private set; } = true;
    public int Hour { get => _hour; }
    public int Minute { get => _minute; }

    #region Private Methods
    private TimeManager() { }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Debug.Log("Time Manager Warning : Null");

        _hour = _startHour;
        _minute = _startMinute;
    }
    private void Update()
    {
        if (!isRunning) return;

        _realAccum += Time.deltaTime;
        if(_realAccum >= _realtimePerGame10Minute)
        {
            _realAccum -= _realtimePerGame10Minute;
            PlusTenMinutes();
        }
    }
    private void PlusTenMinutes()
    {
        _minute += 10;
        if(_minute >= 60)
        {
            _minute = 0;
            _hour += 1;
        }
    }
  #endregion

    #region Public Methods
    public string GetTime()
    {
        return _hour.ToString("00") + ":" + _minute.ToString("00");
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
    #endregion
}
