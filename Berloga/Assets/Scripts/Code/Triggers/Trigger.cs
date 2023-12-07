using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : Command
{
    public Command Command { get; set; }

    private void Awake()
    {
        OnAwake();
    }

    protected virtual void OnAwake()
    {

    }

    public override void Execute()
    {
        Command?.Execute();
    }
}
