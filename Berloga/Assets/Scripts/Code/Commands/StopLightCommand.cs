using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLightCommand : Command
{
    private ICanStopLight _canStopLight;

    private void Awake()
    {
        _canStopLight = GetComponent<ICanStopLight>();
    }

    public override void Execute()
    {
        _canStopLight.StopLight();
    }
}
