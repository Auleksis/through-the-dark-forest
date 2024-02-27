using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [HideInInspector] public Firestore firestore;

    private Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    public void Enable(Vector3 position, Vector3 velocity)
    {
        rb.position = position;
        rb.velocity = velocity;

        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("DISAPPEARED");

        firestore.StoteFireball(gameObject);

        gameObject.SetActive(false);
    }
}
