using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicUnitController : MonoBehaviour
{
    [SerializeField] public StateMachineController stateMachineController;

    private void Start()
    {
        stateMachineController.Init(this);
    }

    private void Update()
    {
        stateMachineController.UpdateState();

        
    }

    private void FixedUpdate()
    {
        stateMachineController.FixedUpdateState();
    }
}
