using System.Collections;
using UnityEngine;


public class CommonRunState : CommonAdditionalState
{
    protected Vector3 v;

    protected float velocity = 1f; //TODO SHOULD BE IN UNIT DATA!!!

    public CommonRunState(CommonStateMachine stateMachine, CommonUnitState commonState, BasicUnitController unitController) : base(stateMachine, commonState, unitController)
    {
    }

    public override void OnMoveInput(Vector3 direction)
    {
        base.OnMoveInput(direction);

        v = direction.normalized * velocity;
    }


    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("walking", true);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        rb.velocity = v;

        SetFlip();

        if (v.sqrMagnitude == 0)
        {
            stateMachine.ChangeState(commonStateMachine.standingState);
        }
    }


    protected void SetFlip()
    {
        if (v.x < 0 && toRight || v.x > 0 && !toRight)
        {
            Vector3 scale = unitController.transform.localScale;
            scale.x *= -1;
            unitController.transform.localScale = scale;

            toRight = !toRight;
        }
    }
}
