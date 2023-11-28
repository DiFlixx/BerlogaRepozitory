using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _addHint;
    [SerializeField]
    private GameObject _removeHint;
    [SerializeField]
    private Transform _commandsContent;
    [SerializeField]
    private Transform _codeContent;
    [SerializeField]
    private GameObject _owner;

    void Start()
    {
        var commands = _owner.GetComponents<Command>();
        foreach (var command in commands)
        {
            CommandView.Create(command.CommandView, transform, command, _commandsContent);
        }
    }

    public void ToggleHints(bool value)
    {
        _addHint.SetActive(value);
        _removeHint.SetActive(value);
    }

    public void HandleDrop(GameObject gameObject, GameObject dropObject)
    {
        if (dropObject == _addHint)
        {
            gameObject.transform.SetParent(_codeContent);
        }
        else if (dropObject == _removeHint)
        {
            Destroy(gameObject);
        }
    }
}
