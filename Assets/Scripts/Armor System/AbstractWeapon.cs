using System.Collections;
using UnityEngine;


public abstract class AbstractWeapon : MonoBehaviour
{
    //[SerializeField] protected int power;

    [SerializeField] protected float cooldown; //IN SECONDS

    protected ArmorController armorController;

    protected bool isAvailable = false;

    protected virtual void Start()
    {

    }

    public abstract void SetEnabled(bool enabled);

    protected virtual void Use()
    {
        
    }

    public virtual void CheckAndUse()
    {
        if (!isAvailable)
            return;

        Use();

        StartCoroutine(Delay());
    }

    protected virtual IEnumerator Delay()
    {
        isAvailable = false;

        yield return new WaitForSeconds(cooldown);

        isAvailable = true;
    }

    public virtual void PickedUp(ArmorController armorController)
    {
        this.armorController = armorController;
        isAvailable = true;
    }
}
