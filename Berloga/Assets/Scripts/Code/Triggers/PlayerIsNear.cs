using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsNear : Trigger
{
    [SerializeField]
    private float _distance;
    private PlayerController _playerController;
    private bool _isNear;

    private void Start()
    {
        _playerController = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        if (Vector3.Distance(_playerController.transform.position, transform.position) <= _distance && !_isNear) 
        {
            _isNear = true;
            Execute();
        }
        else
        {
            _isNear = false;
        }
    }
}
