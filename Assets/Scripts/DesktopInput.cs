using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DesktopInput : MonoBehaviour
{
    [SerializeField] PlayerController player;

    [SerializeField] BasicUnitController unit;

    private Vector3 direction;

    void Update()
    {
        float v_input = Input.GetAxisRaw("Vertical");
        float h_input = Input.GetAxisRaw("Horizontal");

        direction = new Vector3(h_input, v_input, 0);

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            unit.stateMachineController.GetCurrentState().OnClickInput(false, clickedPosition);

            //player.Shoot();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            unit.stateMachineController.GetCurrentState().OnActionInput(GameInputEvent.SWITH_ACTION);
        }


        unit.stateMachineController.GetCurrentState().OnMoveInput(direction);
    }

    private void FixedUpdate()
    {
        //player.Move(direction);

        //unit.HandleInput();
    }
}
