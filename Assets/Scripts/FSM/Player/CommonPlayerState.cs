using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



public class CommonPlayerState : CommonArmoredUnitState
{
    public CommonPlayerState(CommonStateMachine stateMachine, BasicUnitController unitController) : base(stateMachine, unitController)
    {
        actionMode = FightActionMode.ATTACK;

        HandleActionMode();
    }

    public override void OnActionInput(GameInputEvent inputEvent)
    {
        switch (inputEvent) {

            case GameInputEvent.SWITH_ACTION:

                if (actionMode == FightActionMode.ATTACK)
                    actionMode = FightActionMode.TP;
                else
                    actionMode = FightActionMode.ATTACK;

                HandleActionMode();

                break;
        }
    }

    public override void OnClickInput(bool right, Vector3 pos)
    {
        //IF ACTION SHOULD BE DONE (LEFT)
        if (!right)
        {
            switch (actionMode)
            {
                case FightActionMode.ATTACK:

                    armedUnit.armorController.UseWeapon();

                    break;


                case FightActionMode.TP:

                    rb.position = pos;

                    break;
            }
        }
    }


    
}

