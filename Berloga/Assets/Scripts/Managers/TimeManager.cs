using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class TimeManager : MonoBehaviour
{
    public UnityEvent<DayTime> DayTimeChanged;

    [SerializeField]
    private float _fullDayLen = 720f;
    [SerializeField]
    private DayTime _startTime = DayTime.Day;
    [SerializeField]
    private Light2D _globalLight;

    private float time;
    private float _dayPartTime;
    private int _currentDayTime;

    private void Awake()
    {
        _dayPartTime = _fullDayLen / (int)DayTime.Size;
        _currentDayTime = (int)_startTime;
    }

    public DayTime GetDayTime()
    {
        return (DayTime)_currentDayTime; 
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > _dayPartTime) 
        {
            time = 0;
            _currentDayTime = (_currentDayTime + 1)%(int)DayTime.Size;
            DayTimeChanged?.Invoke(GetDayTime());
        }
        
    }
}
