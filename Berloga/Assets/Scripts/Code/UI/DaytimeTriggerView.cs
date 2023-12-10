using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DaytimeTriggerView : CommandView
{
    [SerializeField]
    private TMP_Dropdown dropdown;
    private Dictionary<string, DayTime> _keyValuePairs;

    protected override void OnAwake()
    {
        _keyValuePairs = new Dictionary<string, DayTime>()
        {
            { "Утро наступило", DayTime.Morning },
            { "День наступил", DayTime.Day },
            { "Вечер наступил", DayTime.Evening },
            { "Ночь наступила", DayTime.Night }
        };
        dropdown.ClearOptions();
        foreach (var key in _keyValuePairs.Keys)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(key));
        }
        
    }

    public override void InitCommand()
    {
        DaytimeTrigger daytimeTrigger = Command as DaytimeTrigger;
        daytimeTrigger.DayTime = _keyValuePairs[dropdown.options[dropdown.value].text];
        base.InitCommand();
    }
}
