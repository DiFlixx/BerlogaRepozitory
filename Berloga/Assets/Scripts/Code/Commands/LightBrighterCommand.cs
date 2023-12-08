using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBrigterCommand : Command
{
    private ICanLightBrighter _canLightBrighter;

    private void Awake()
    {
        _canLightBrighter = GetComponent<ICanLightBrighter>();
    }

    public override void Execute()
    {
        _canLightBrighter.LightBrighter();
    }
}
