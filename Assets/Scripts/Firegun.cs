using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firegun : MonoBehaviour
{
    [SerializeField] Firestore firestore;

    [SerializeField] Transform sourcePoint;

    [SerializeField] float fireballVelocity = 5f;


    public void Shoot(Vector3 direction)
    {
        GameObject fireballObj = firestore.GetFireball();

        Fireball fireball = fireballObj.GetComponent<Fireball>();

        Vector3 velocity = direction.normalized * fireballVelocity;

        fireball.Enable(sourcePoint.position, velocity);
    }
}
