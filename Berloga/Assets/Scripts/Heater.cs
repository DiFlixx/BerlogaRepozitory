using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heater : MonoBehaviour, ITurnOffable, ITurnOnable
{
    [SerializeField]
    private CodePanel _codePanel;
    [SerializeField]
    private Color highlightColor = Color.yellow;


    private Color _originalColor;
    private Renderer _renderer;
    private bool canActivate = true;
    private bool isMouse = false;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canActivate && isMouse)
        {
            ActivatePanel();
        }
    }

    private void ActivatePanel()
    {
        _codePanel.gameObject.SetActive(true);
    }

    void OnMouseEnter()
    {
        _renderer.material.color = highlightColor;
        isMouse = true;
    }

    void OnMouseExit()
    {
        _renderer.material.color = _originalColor;
        isMouse = false;
    }
}
