using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected Color _originalColor;
    protected SpriteRenderer _spriteRenderer;
    protected bool canActivate = true;
    public bool isMouse = false;

    [SerializeField]
    protected CodePanel _codePanel;
    [SerializeField]
    protected Color highlightColor = Color.yellow;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.material.color;
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
        _spriteRenderer.material.color = highlightColor;
        isMouse = true;
    }

    void OnMouseExit()
    {
        _spriteRenderer.material.color = _originalColor;
        isMouse = false;
    }
}
