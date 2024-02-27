using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CommonUnitState : BasicState
{
    protected Animator animator;

    protected CommonStateMachine commonStateMachine;

    public CommonUnitState(CommonStateMachine stateMachine, BasicUnitController unitController) : base(stateMachine, unitController)
    {
        animator = unitController.GetComponent<Animator>();

        commonStateMachine = stateMachine;
    }

    public override void OnActionInput(GameInputEvent inputEvent)
    {
    }

    public override void OnClickInput(bool right, Vector3 pos)
    {
    }

    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnHurt()
    {
    }

    public override void OnMoveInput(Vector3 direction)
    {

    }

    public override void OnUpdate()
    {
    }
}

