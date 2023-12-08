using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _removeHint;
    [SerializeField]
    private RectTransform _commandsContent;
    [SerializeField]
    private RectTransform _triggersContent;
    [SerializeField]
    private RectTransform _commandContainer;
    [SerializeField]
    private RectTransform _triggerContainer;
    [SerializeField]
    private GameObject _owner;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private Image _icon;

    private void Awake()
    {
        GameObject obj = new GameObject(this.GetType().Name);
    }

    void Start()
    {
        _icon.sprite = _owner.GetComponentInChildren<SpriteRenderer>().sprite;
        var commands = _owner.GetComponents<Command>();
        foreach (var command in commands)
        {
            if (command is Trigger)
            {
                CommandView.Create(command.CommandView, this, command, _triggersContent);
            }
            else
            {
                CommandView.Create(command.CommandView, this, command, _commandsContent);
            }
        }
    }

    private void OnEnable()
    {
        _button?.onClick.AddListener(Compile);
    }

    private void OnDisable()
    {
        _button?.onClick.RemoveListener(Compile);
    }

    private void Compile()
    {
        if (_commandContainer.childCount > 0 && _triggerContainer.childCount > 0)
        {
            Trigger trigger = _triggerContainer.GetChild(0).GetComponent<CommandView>().Command as Trigger;
            Command command = _commandContainer.GetChild(0).GetComponent<CommandView>().Command;
            trigger.Command = command;
        }
        gameObject.SetActive(false);
    }

    public void ToggleHints(bool value)
    {
        _removeHint.SetActive(value);
    }

    public void HandleDrop(GameObject gameObject, GameObject dropObject)
    {
        if (dropObject == _removeHint || dropObject == null)
        {
            Destroy(gameObject);
        }
        else
        {
            if (gameObject.CompareTag("TriggerView"))
            {
                if (_triggerContainer.childCount > 0)
                    Destroy(_triggerContainer.GetChild(0).gameObject);
                gameObject.transform.SetParent(_triggerContainer);
            }
            else
            {
                if (_commandContainer.childCount > 0)
                    Destroy(_commandContainer.GetChild(0).gameObject);
                gameObject.transform.SetParent(_commandContainer);
            }
        }
    }

    public void UpdateUI()
    {
        //LayoutRebuilder.ForceRebuildLayoutImmediate(_codeContent);
    }
}
