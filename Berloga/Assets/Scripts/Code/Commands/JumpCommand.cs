using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : Command
{
    [SerializeField]
    private Spring _spring;

    public override void Execute()
    {
        _spring.SuperJump();    
    }
}
