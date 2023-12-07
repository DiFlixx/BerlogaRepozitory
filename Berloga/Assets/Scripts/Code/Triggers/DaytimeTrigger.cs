using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaytimeTrigger : Trigger
{
    public DayTime DayTime { get; set; }

    private TimeManager _timeManager;

    protected override void OnAwake()
    {
        _timeManager = FindAnyObjectByType<TimeManager>();
    }

    private void OnEnable()
    {
        _timeManager.DayTimeChanged.AddListener(OnDayTimeChanged);
    }

    private void OnDisable()
    {
        _timeManager.DayTimeChanged.RemoveListener(OnDayTimeChanged);
    }

    private void OnDayTimeChanged(DayTime daytime)
    {
        if (daytime == DayTime) Execute();
    }
}
