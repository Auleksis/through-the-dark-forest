using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum FightActionMode
{
    NONE,
    ATTACK,
    TP,
};

public class CommonArmoredUnitState : CommonUnitState
{
    protected ArmedUnitController armedUnit;

    protected FightActionMode actionMode;

    public CommonArmoredUnitState(CommonStateMachine stateMachine, BasicUnitController unitController) : base(stateMachine, unitController)
    {
        actionMode = FightActionMode.NONE;

        armedUnit = (ArmedUnitController)unitController;
    }

    public override void OnActionInput(GameInputEvent inputEvent)
    {
        base.OnActionInput(inputEvent);

        if (armedUnit.peaceful)
            return;


        switch (inputEvent)
        {
            case GameInputEvent.SWITH_ACTION:

                actionMode = (FightActionMode)(((int)actionMode + 1) % 2);

                HandleActionMode();

                break;
        }
    }

    public override void OnClickInput(bool right, Vector3 pos)
    {
        base.OnClickInput(right, pos);

        if (armedUnit.peaceful)
            return;

        if (!right)
        {
            switch (actionMode)
            {
                case FightActionMode.ATTACK:

                    armedUnit.armorController.UseWeapon();

                    break;
            }
        }
    }



    //ANIM CONTROL

    protected void HandleActionMode()
    {
        switch (actionMode)
        {
            case FightActionMode.ATTACK:

                animator.SetBool("armored", true);

                armedUnit.armorController.SetWeaponEnabled(true);

                break;

            default:

                animator.SetBool("armored", false);

                armedUnit.armorController.SetWeaponEnabled(false);

                break;
        }
    }
}

