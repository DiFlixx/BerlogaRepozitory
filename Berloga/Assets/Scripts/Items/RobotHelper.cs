using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHelper : Item
{
    enum States
    {
        Follow,
        Finding
    }

    [SerializeField]
    private float _speed;
    [SerializeField]
    private PlayerController _controller;
    [SerializeField]
    private Inventory _inventory;
    [SerializeField]
    private float _distance;
    private States _state;
    private GameObject _currentTarget;


    public void FindFood()
    {
        _state = States.Finding;
        var food = FindObjectsOfType<FoodPickup>();
        GameObject obj = null;
        float distance = 0f;
        foreach (var i in food)
        {
            if (obj != null)
            {
                var distance2 = Vector3.Distance(transform.position, i.transform.position);
                if (distance2 < distance)
                {
                    distance = distance2;
                    obj = i.gameObject;
                }
            }
            else
            {
                obj = i.gameObject;
                distance = Vector3.Distance(transform.position, obj.transform.position);
            }
        }
        _currentTarget = obj;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _currentTarget.transform.position, Time.deltaTime * _speed);
        if (_state == States.Follow) 
        {
            _currentTarget = _controller.gameObject;
        }
        if (Vector3.Distance(transform.position, _controller.transform.position) > _distance)
        {
            _inventory.gameObject.SetActive(false);
        }
        else
        {
            _inventory.gameObject.SetActive(true);
        }
    }

    private void Awake()
    {
        _state = States.Follow; _currentTarget = _controller.gameObject;
    }

    public void FoodPicked()
    {

    }
}
