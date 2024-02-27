using System.Collections;
using UnityEngine;


public enum SpellMode
{
    ATTACK
};

public class Spell : AbstractWeapon
{
    [SerializeField] protected BasicBall spellBall;

    [SerializeField] protected SpellMode mode;

    [SerializeField] public BallStore ballStore;

    protected override void Start()
    {
        base.Start();

        ballStore.AddSpell(this);
    }
    


    //TO USE DIFFERENT MODES OF SPELLS 
    //THERE WILL BE ANOTHER FUNCTION THAT SETS THE MODE
    //IN THIS FUNCTION A SWITCH-CASE WILL BE PRESENT
    protected override void Use()
    {
        base.Use();

        switch(mode)
        {
            case SpellMode.ATTACK:
                UseAttackSpell();
                break;
        }
    }


    public void SetSpellBall(BasicBall ball)
    {
        spellBall = ball;

        spellBall.SetInHandMode();
    }

    public override void PickedUp(ArmorController armorController)
    {
        base.PickedUp(armorController);

        transform.position = armorController.spellPlace.position;

        spellBall.SetInHandMode();

        spellBall.SetPosition(transform.position);
    }


    //SPELL LOGIC

    private void UseAttackSpell()
    {
        Vector3 direction = armorController.GetAttackDirection();


        //CREATE A NEW SPELL BALL

        GameObject usedBallObject = ballStore.GetBall(this);

        BasicBall usedBall = usedBallObject.GetComponent<BasicBall>();

        usedBall.SetPosition(transform.position);

        usedBall.SetActiveMode();

        usedBall.Shoot(direction);

        usedBall.AfterHit += StoreBall;
    }


    protected virtual void StoreBall(BasicBall ball)
    {
        ball.AfterHit -= StoreBall;
        ballStore.AddBall(ball.gameObject, this);
    }




    public BasicBall GetSpellBall()
    {
        return spellBall;
    }

    public void SetMode(SpellMode mode)
    {
        this.mode = mode;
    }

    public SpellMode GetMode()
    {
        return mode;
    }

    public override void SetEnabled(bool enabled)
    {
        spellBall.gameObject.SetActive(enabled);
    }
}
