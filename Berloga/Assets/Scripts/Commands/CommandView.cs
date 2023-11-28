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
    private Transform _parent;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        Image = GetComponent<Image>();
        _codePanel = FindObjectOfType<CodePanel>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _codePanel.ToggleHints(true);
        if (!IsCloned)
        {
            _cloneObj = Create(this, _parent, Command, _parent);
            _cloneObj.RectTransform.position = RectTransform.position;
            _cloneObj.IsCloned = true;
            _cloneObj.Image.raycastTarget = false;
        }
        else
        {
            transform.SetParent(_parent, true);
            Image.raycastTarget = false;
        }
        
    }

    public static CommandView Create(CommandView obj, Transform parent, Command command, Transform commandContent)
    {
        var view = Instantiate(obj, commandContent);
        view._parent = parent;
        view.Command = command;
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

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerEnter);
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
    }
}
