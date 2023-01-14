using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovementMoveBaseState : PlayerMovementBaseState
{
    protected PlayerMovementMoveBaseState(PlayerMovement controller) : base(controller)
    {
    }

    public override void Update()
    {
        controller.Move();

        if (!controller.IsMoving())
        {
            controller.ChangeState(new PlayerMovementIdleState(controller));
        }
    }
}
