using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RobotHelper : Item, ITurnOnable, ITurnOffable
{
    enum States
    {
        Follow,
        Finding
    }

    [SerializeField]
    private GameObject _c1;
    [SerializeField]
    private GameObject _c2;

    [SerializeField]
    private float _speed;
    private GameObject _controller;
    [SerializeField]
    private GameObject _inventoryUI;
    [SerializeField]
    private Inventory _inventory;
    [SerializeField]
    private float _distance;
    private States _state;
    private GameObject _currentTarget;
    private Stack<GameObject> _stack;
    private bool _foodFound;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Vector2 previousPosition;

    public void FindFood()
    {
        if (IsInventoryFull())
        {
            return;
        }
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
        if (obj != null)
        {
            _state = States.Finding;
            _currentTarget = obj;
            _stack.Push(obj);
        }
    }

    private void FixedUpdate()
    {
        if (_state == States.Follow) 
        {
            _currentTarget = _controller.gameObject;
        }
        else if (_state == States.Finding)
        {
            if (_stack.Count == 0 || IsInventoryFull())
            {
                _state = States.Follow;
            }
            if (!_foodFound && _stack.Count > 0)
            {
                _foodFound = true;
                _currentTarget = _stack.Pop();
            }
        }
        if (Vector3.Distance(transform.position, _controller.transform.position) > _distance)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
        Vector2 currentPosition = _rb.position;
        Vector2 movement = currentPosition - previousPosition;
        float speedX = movement.x / Time.deltaTime;
        previousPosition = currentPosition;
        if ((speedX > 0 && !_spriteRenderer.flipX) || (speedX < 0 && _spriteRenderer.flipX))
        {
            Flip();
        }
        if (_currentTarget != null)
            transform.position = Vector3.Lerp(transform.position, _currentTarget.transform.position, Time.deltaTime * _speed);
    }

    private void Awake()
    {
        _controller = _c1;
        _state = States.Follow; _currentTarget = _controller.gameObject;
        _stack = new Stack<GameObject>();
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FoodPicked()
    {
        _foodFound = false;
        if (IsInventoryFull())
        {
            _stack.Clear();
        }
    }

    private bool IsInventoryFull()
    {
        bool full = true;
        foreach (Slot slot in _inventory.slots)
        {
            if (!slot.IsFull)
            {
                full = false; break;
            }
        }
        return full;
    }

    void Flip()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }

    public void TurnOn()
    {
        _inventoryUI.gameObject.SetActive(true);
    }

    public void TurnOff()
    {
        _inventoryUI.gameObject.SetActive(false);
    }

    public void ChangePlayer(int value)
    {
        if (value == 1)
        {
            _controller = _c1;
        }
        else if (value == 2)
        {
            _controller = _c2;
        }
    }
}
