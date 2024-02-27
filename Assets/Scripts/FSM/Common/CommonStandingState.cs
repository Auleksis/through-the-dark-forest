using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class CommonStandingState : CommonAdditionalState
{
    public CommonStandingState(CommonStateMachine stateMachine, CommonUnitState commonState, BasicUnitController unitController) : base(stateMachine, commonState, unitController)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("walking", false);
    }

    public override void OnMoveInput(Vector3 direction)
    {
        base.OnMoveInput(direction);

        if (direction.sqrMagnitude > 0)
            stateMachine.ChangeState(commonStateMachine.runState);
    }
}

