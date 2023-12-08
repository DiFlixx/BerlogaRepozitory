using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveFood : Command
{
    private ICanGiveFood _giveFood;

    private void Awake()
    {
        _giveFood = GetComponent<ICanGiveFood>();
    }

    public override void Execute()
    {
        _giveFood.GiveFood();
    }
}
