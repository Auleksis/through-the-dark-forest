using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum GameInputEvent
{
    MOVE, //WASD
    FIRE, //MOUSE LEFT
    DEFEND, //MOUSE RIGHT
    SWITH_ACTION,
};

public abstract class BasicState
{
    protected StateMachineController stateMachine;

    protected BasicUnitController unitController;

    protected Rigidbody2D rb;

    protected static bool toRight;

    public BasicState(StateMachineController stateMachine, BasicUnitController unitController)
    {
        this.stateMachine = stateMachine;
        this.unitController = unitController;

        toRight = true;

        rb = unitController.GetComponent<Rigidbody2D>();
    }

    public abstract void OnEnter();

    public abstract void OnUpdate();

    public abstract void OnFixedUpdate();

    public abstract void OnExit();

    public abstract void OnHurt();



    //INPUT GROUP

    public abstract void OnMoveInput(Vector3 direction);

    public abstract void OnClickInput(bool right, Vector3 pos);

    public abstract void OnActionInput(GameInputEvent inputEvent);
}
