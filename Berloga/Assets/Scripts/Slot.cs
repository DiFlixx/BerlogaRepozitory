using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool IsFull = false;

    [SerializeField] 
    int slotIndex = 0;

    private Inventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
    }

    public void MakeSlotEmpty()
    {
        foreach (Transform child in transform)
        {
            if (!child.CompareTag("Cross"))
            {
                GameObject.Destroy(child.gameObject);
                IsFull = false;
            }
        }
    }

    public void DropItem()
    {
        MakeSlotEmpty();
    }
}
