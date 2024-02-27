using System.Collections;
using UnityEngine;


public class ArmorController : MonoBehaviour
{
    [SerializeField] public Transform spellPlace;

    [SerializeField] AbstractWeapon currentWeapon;

    private void Start()
    {
        currentWeapon?.PickedUp(this);
    }

    public Vector3 GetAttackDirection()
    {
        return transform.localScale.x > 0 ? Vector3.right : Vector3.left;
    }

    public void UseWeapon()
    {
        currentWeapon?.CheckAndUse();
    }

    public void SetWeaponEnabled(bool enabled)
    {
        currentWeapon?.gameObject.SetActive(enabled);

        if (enabled)
            currentWeapon?.PickedUp(this);
    }
}
