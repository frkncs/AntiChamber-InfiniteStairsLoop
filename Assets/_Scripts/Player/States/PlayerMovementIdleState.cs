using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementIdleState : PlayerMovementBaseState
{
    public PlayerMovementIdleState(PlayerMovement controller) : base(controller)
    {
        controller.SetWalkSpeed();
    }

    public override void Update()
    {
        if (controller.IsMoving())
        {
            controller.ChangeState(new PlayerMovementWalkState(controller));
        }
    }
}
