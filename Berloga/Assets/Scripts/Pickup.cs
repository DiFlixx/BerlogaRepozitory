using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public SlotItem Itembutton;

    private Inventory _inventory;

    protected abstract Action GetAction();
        
    void Start()
    {
        _inventory = FindAnyObjectByType<Inventory>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<RobotHelper>(out var robot))
        {
            for (int i = 0; i < _inventory.slots.Length; i++)
            {
                if (_inventory.slots[i].IsFull == false)
                {
                    robot.FoodPicked();
                    _inventory.slots[i].IsFull = true;
                    Instantiate(Itembutton, _inventory.slots[i].transform, false).Init(_inventory.slots[i], GetAction());
                    Destroy(gameObject);
                    break;
                }
            }
        }
        else if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < _inventory.slots.Length; i++)
            {
                if (_inventory.slots[i].IsFull == false)
                {
                    _inventory.slots[i].IsFull = true;
                    Instantiate(Itembutton, _inventory.slots[i].transform, false).Init(_inventory.slots[i], GetAction());
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
