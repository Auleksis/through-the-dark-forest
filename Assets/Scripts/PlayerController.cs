using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocity = 3f;


    [SerializeField] Firegun firegun;


    private Rigidbody2D rb;
    private Animator animator;

    private bool toRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

    }


    //BEHAVIOUR LOGIC


    public void Move(Vector3 direction)
    {
        Vector3 v = direction.normalized * velocity;
        
        rb.velocity = v;

        SetWalkingAnimation(v.sqrMagnitude != 0);

        SetFlip(v);
    }

    public void Teleportate(Vector3 point)
    {
        rb.position = point;
    }



    //ANIMATIONS AND ALL ABOUT LOOK


    private void SetWalkingAnimation(bool isWalking)
    {
        animator.SetBool("walking", isWalking);
    }

    private void SetFlip(Vector3 v)
    {
        if(v.x < 0 && toRight || v.x > 0 && !toRight)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            toRight = !toRight;
        }
    }


    public void Shoot()
    {
        Vector3 direction = Vector3.right * (toRight ? 1 : -1);

        firegun.Shoot(direction);
    }
}
