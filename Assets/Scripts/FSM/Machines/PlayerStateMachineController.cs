using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "Player Machine", menuName = "State Machines/Player Machine", order = 1)]
public class PlayerStateMachineController : CommonStateMachine
{
    public override void Init(BasicUnitController unitController)
    {
        commonState = new CommonPlayerState(this, unitController);

        standingState = new PlayerStandingState(this, commonState, unitController);

        runState = new PlayerRunState(this, commonState, unitController);

        ChangeState(standingState);
    }
}
