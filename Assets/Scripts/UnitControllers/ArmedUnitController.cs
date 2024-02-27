using System.Collections;
using UnityEngine;



public class ArmedUnitController : InventoryUnitController
{
    [SerializeField][HideInInspector] public ArmorController armorController;
    [SerializeField] public bool peaceful = false;

    private void Awake()
    {
        armorController = GetComponent<ArmorController>();
    }
}
