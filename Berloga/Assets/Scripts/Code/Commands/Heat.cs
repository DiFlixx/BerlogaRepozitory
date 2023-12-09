using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heat : Command
{
    [SerializeField]
    private Heater _heater;

    public override void Execute()
    {
        _heater.Heat();
    }
}
