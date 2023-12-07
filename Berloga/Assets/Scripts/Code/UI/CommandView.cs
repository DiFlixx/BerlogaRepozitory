using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CommandView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Command Command { get; set; }
    public Image Image { get; private set; }
    public RectTransform RectTransform { get; private set; }
    public bool IsCloned { get; set; }

    [SerializeField]
    private TextMeshProUGUI _commandText;
    private CommandView _cloneObj;
    private CodePanel _codePanel;

    public virtual void InitCommand() { }

    protected virtual void OnAwake() { }

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        Image = GetComponent<Image>();
        OnAwake();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _codePanel.ToggleHints(true);
        if (!IsCloned)
        {
            _cloneObj = Create(this, _codePanel, Command, _codePanel.transform);
            _cloneObj.RectTransform.position = RectTransform.position;
            _cloneObj.IsCloned = true;
            _cloneObj.Image.raycastTarget = false;
        }
        else
        {
            transform.SetParent(_codePanel.transform, true);
            Image.raycastTarget = false;
        }
        _codePanel.UpdateUI();
    }

    public static CommandView Create(CommandView obj, CodePanel codePanel, Command command, Transform parent)
    {
        var view = Instantiate(obj, parent);
        view._codePanel = codePanel;
        view.Command = command;
        if (view._commandText != null)
            view._commandText.text = command.CommandName;
        return view;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsCloned)
        {
            _cloneObj.RectTransform.position += (Vector3)eventData.delta;

        }
        else
        {
            RectTransform.position += (Vector3)eventData.delta;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!IsCloned)
        {
            _cloneObj.Image.raycastTarget = true;
            _codePanel.HandleDrop(_cloneObj.gameObject, eventData.pointerEnter);

        }
        else
        {
            Image.raycastTarget = true;
            _codePanel.HandleDrop(gameObject, eventData.pointerEnter);
        }
        _codePanel.ToggleHints(false);
        _codePanel.UpdateUI();
    }
}
