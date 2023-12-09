using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFoodDropped : Trigger
{
    private FoodMachine[] _foodMachines;

    void Start()
    {
        _foodMachines = FindObjectsOfType<FoodMachine>();
        foreach (var i in _foodMachines)
        {
            i.OnFoodDropped.AddListener(Execute);
        }
    }
}
