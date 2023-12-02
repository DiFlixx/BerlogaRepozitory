using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnCommand : Command
{
    private ITurnOnable _turnOnAble;

    private void Awake()
    {
        _turnOnAble = GetComponent<ITurnOnable>();
    }

    public override IEnumerator Execute()
    {
        _turnOnAble.TurnOn();
        yield return null;
    }
}
