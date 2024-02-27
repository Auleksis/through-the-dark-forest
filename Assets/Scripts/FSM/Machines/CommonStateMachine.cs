using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "Common Machine", menuName = "State Machines/Common Machine", order = 2)]
public class CommonStateMachine : StateMachineController
{
    protected CommonArmoredUnitState commonState; //NOT SET TO STATE MACHINE!

    public CommonStandingState standingState;

    public CommonRunState runState;

    public override void Init(BasicUnitController unitController)
    {
        commonState = new CommonArmoredUnitState(this, unitController);

        standingState = new CommonStandingState(this, commonState, unitController);

        runState = new CommonRunState(this, commonState, unitController);

        ChangeState(standingState);
    }
}
