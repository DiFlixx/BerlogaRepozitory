using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickup : Pickup
{
    protected override Action GetAction()
    {
        return () => 
        {
            HungerSystem hungerSystem = GameObject.FindAnyObjectByType<HungerSystem>();
            hungerSystem.Eat(1);
        };
    }
}
