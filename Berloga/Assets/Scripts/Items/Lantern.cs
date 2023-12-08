using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : Item, ICanLight, ICanStopLight, ICanLightBrighter
{
    [SerializeField]
    private CodePanel _codePanel;
    [SerializeField]
    private Color highlightColor = Color.yellow;
    [SerializeField]
    private GameObject _light;
    [SerializeField]
    private GameObject _light2;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
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

    public void Light()
    {
        _light.gameObject.SetActive(true);
        _light2.gameObject.SetActive(false);
    }

    public void StopLight()
    {
        _light2.gameObject.SetActive(false);
        _light.gameObject.SetActive(false);
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

    public void LightBrighter()
    {
        _light.gameObject.SetActive(false);
        _light2.gameObject.SetActive(true);
    }
}
