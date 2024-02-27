using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class StateMachineController : MonoBehaviour
{
    protected BasicState currentState;
    

    //IN THIS METHOD ALL STATES FOR MACHINE ARE CREATED
    public abstract void Init(BasicUnitController unitController);

    public void ChangeState(BasicState newState)
    {
        currentState?.OnExit();

        currentState = newState;

        currentState.OnEnter();
    }

    public void UpdateState()
    {
        currentState?.OnUpdate();
    }

    public void FixedUpdateState()
    {
        currentState?.OnFixedUpdate();
    }

    public BasicState GetCurrentState()
    {
        return currentState;
    }
}
