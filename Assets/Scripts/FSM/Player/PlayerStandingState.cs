using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStandingState : CommonStandingState
{
    public PlayerStandingState(CommonStateMachine stateMachine, CommonUnitState commonState, BasicUnitController unitController) : base(stateMachine, commonState, unitController)
    {
    }
}
