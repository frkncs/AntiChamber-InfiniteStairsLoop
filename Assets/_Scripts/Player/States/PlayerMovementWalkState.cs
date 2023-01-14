using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWalkState : PlayerMovementMoveBaseState
{
    public PlayerMovementWalkState(PlayerMovement controller) : base(controller)
    {
        controller.SetWalkSpeed();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            controller.ChangeState(new PlayerMovementRunState(controller));
        }
    }
}
