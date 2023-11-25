using System.Collections;
using System.Collections.Generic;
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
    private Transform _content;

    void Start()
    {
        
    }

    void Update()
    {
        
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
            gameObject.transform.parent = _content;
        }
        else if (dropObject == _removeHint)
        {
            Destroy(gameObject);
        }
    }
}
