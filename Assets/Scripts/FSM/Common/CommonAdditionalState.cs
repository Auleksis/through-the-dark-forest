using System.Collections;
using UnityEngine;


public abstract class CommonAdditionalState : CommonUnitState
{

    protected CommonUnitState commonState;

    protected CommonAdditionalState(CommonStateMachine stateMachine, CommonUnitState commonState, BasicUnitController unitController) : base(stateMachine, unitController)
    {
        this.commonState = commonState;
    }


    public override void OnActionInput(GameInputEvent inputEvent)
    {
        commonState.OnActionInput(inputEvent);
    }

    public override void OnClickInput(bool right, Vector3 pos)
    {
        commonState.OnClickInput(right, pos);
    }

    public override void OnEnter()
    {
        commonState.OnEnter();
    }

    public override void OnExit()
    {
        commonState.OnExit();
    }

    public override void OnFixedUpdate()
    {
        commonState.OnFixedUpdate();
    }

    public override void OnHurt()
    {
        commonState.OnHurt();
    }

    public override void OnMoveInput(Vector3 direction)
    {
        commonState.OnMoveInput(direction);
    }

    public override void OnUpdate()
    {
        commonState.OnUpdate();
    }
}
