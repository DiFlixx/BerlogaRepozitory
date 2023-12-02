using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : Command
{
    public List<Command> Commands { get; private set; }

    private void Awake()
    {
        Commands = new List<Command>();
        OnAwake();
    }

    protected virtual void OnAwake()
    {

    }
}
