using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : Item, ITurnOffable, ITurnOnable
{
    private PlayerController _controller;

    private Vector3 _startPosition;

    private bool _isOn;
    public void TurnOff()
    {
        transform.position = _startPosition - new Vector3(0, 0.2f, 0);
        _isOn = false;
    }

    public void TurnOn()
    {
        transform.position = _startPosition;
        _isOn = true;
    }

    public void SuperJump()
    {
        if (_isOn)
        {
            _controller.SuperJump();
        }
    }

    private void Awake()
    {
        _controller = FindObjectOfType<PlayerController>();
        _startPosition = transform.position;
        TurnOff();
    }
}
