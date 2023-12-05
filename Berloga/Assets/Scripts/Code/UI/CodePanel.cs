using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    public RectTransform CommandsContent => _commandsContent;
    public RectTransform CodeContent => _codeContent;

    [SerializeField]
    private GameObject _removeHint;
    [SerializeField]
    private RectTransform _commandsContent;
    [SerializeField]
    private RectTransform _codeContent;
    [SerializeField]
    private GameObject _owner;
    [SerializeField]
    private Button _button;

    private CodeManager _codeManager;
    private Coroutine _codeCoroutine;
    private List<Func<IEnumerator>> _actions;

    private void Awake()
    {
        GameObject obj = new GameObject(this.GetType().Name);
        _codeManager = obj.AddComponent<CodeManager>();
        _actions = new List<Func<IEnumerator>>();
    }

    void Start()
    {
        var commands = _owner.GetComponents<Command>();
        foreach (var command in commands)
        {
            CommandView.Create(command.CommandView, this, command, _commandsContent);
        }
    }

    private void OnEnable()
    {
        _button?.onClick.AddListener(Compile);
        if (_codeCoroutine != null)
        {
            StopCoroutine(_codeCoroutine);
        }
    }

    private void OnDisable()
    {
        _button?.onClick.RemoveListener(Compile);
    }

    private IEnumerator Execute()
    { 
        gameObject.SetActive(false);
        //ile (true)
        //
            foreach (var action in _actions)
            {
                Debug.Log("dsadawd");
                yield return _codeManager.StartCoroutine(action());
                yield return new WaitForSeconds(0.3f);
            }
        //
    }

    private void Compile()
    {
        _actions.Clear();
        foreach(Transform child in CodeContent)
        {
            CommandView commandView = child.GetComponent<CommandView>();
            commandView.InitCommand();
            if (child.CompareTag("TriggerView"))
            {
                var trigger = commandView.Command as Trigger;
                trigger.Commands.Clear();
                foreach (Transform triggerChild in child)
                {
                    if (triggerChild.CompareTag("CommandView"))
                    {
                        commandView = triggerChild.GetComponent<CommandView>();
                        commandView.InitCommand();
                        trigger.Commands.Add(commandView.Command);
                    }
                }
            }
            else if (child.CompareTag("CommandView"))
            {
                _actions.Add(commandView.Command.Execute);
            }
        }
        _codeCoroutine = _codeManager.StartCoroutine(Execute());
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
        else if (dropObject.CompareTag("TriggerView"))
        {
            if (gameObject.CompareTag("TriggerView"))
            {
                gameObject.transform.SetParent(_codeContent);
            }
            else
            {
                gameObject.transform.SetParent(dropObject.transform);
            }
        }
        else if (dropObject.CompareTag("CommandView") && dropObject.transform.parent.CompareTag("TriggerView"))
        {
            gameObject.transform.SetParent(dropObject.transform.parent);
        }
        else
        {
            gameObject.transform.SetParent(_codeContent);
        }
    }

    public void UpdateUI()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(_codeContent);
    }
}
