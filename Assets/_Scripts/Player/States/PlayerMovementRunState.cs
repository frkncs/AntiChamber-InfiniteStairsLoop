using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRunState : PlayerMovementMoveBaseState
{
    public PlayerMovementRunState(PlayerMovement controller) : base(controller)
    {
        controller.SetRunSpeed();
    }

    public override void Update()
    {
        base.Update();
        
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            controller.ChangeState(new PlayerMovementWalkState(controller));
        }
    }
}
