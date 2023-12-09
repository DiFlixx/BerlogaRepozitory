using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFood : Command
{
    [SerializeField]
    private RobotHelper _robotHelper;

    public override void Execute()
    {
        _robotHelper.FindFood();
    }
}
