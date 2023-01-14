using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovementBaseState
{
    protected PlayerMovement controller;

    public PlayerMovementBaseState(PlayerMovement controller)
    {
        this.controller = controller;
    }
    
    public abstract void Update();
}
