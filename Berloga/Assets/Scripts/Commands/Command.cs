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

    public abstract IEnumerator Execute();
}
