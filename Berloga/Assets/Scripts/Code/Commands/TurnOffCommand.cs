using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffCommand : Command
{
    private ITurnOffable _turnOffAble;

    private void Awake()
    {
        _turnOffAble = GetComponent<ITurnOffable>();
    }

    public override void Execute()
    {
        _turnOffAble.TurnOff();
    }
}
