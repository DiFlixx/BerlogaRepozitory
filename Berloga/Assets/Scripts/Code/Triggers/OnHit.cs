using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class OnHit : Trigger
{
    [SerializeField]
    private float _distance = 1f;
    [SerializeField]
    private Item _owner;
    private Camera _mainCamera;
    private PlayerController _playerController;

    private void Start()
    {
        _mainCamera = Camera.main;
        _playerController = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _owner.isMouse)
        {
            if (Vector3.Distance(_playerController.transform.position, transform.position) <= _distance)
            {
                Execute();
            }
        }
    }
}
