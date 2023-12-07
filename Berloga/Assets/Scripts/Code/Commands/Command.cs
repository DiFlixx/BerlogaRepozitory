using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : MonoBehaviour
{
    public string CommandName => _commandName;

    public CommandView CommandView => _commandView;
    [SerializeField]
    private CommandView _commandView;
    [SerializeField]
    private string _commandName;

    protected CodeManager _codeManager;

    public void Init(CodeManager codeManager)
    {
        _codeManager = codeManager;
    }

    public abstract void Execute();
}
