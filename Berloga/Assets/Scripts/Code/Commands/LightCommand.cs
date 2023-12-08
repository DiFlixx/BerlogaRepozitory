using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCommand : Command
{
    private ICanLight _canLight;

    private void Awake()
    {
        _canLight = GetComponent<ICanLight>();
    }

    public override void Execute()
    {
        _canLight.Light();
    }
}
