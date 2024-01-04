using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Button _button;
    
    public GameObject _container;

    private Slot _slot;

    public void Init(Slot slot, Action action)
    {
        _slot = slot;
        _button.onClick.AddListener(slot.MakeSlotEmpty);
        _button.onClick.AddListener(action.Invoke);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }
}
