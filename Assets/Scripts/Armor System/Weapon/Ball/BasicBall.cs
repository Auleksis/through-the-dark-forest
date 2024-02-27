using System;
using System.Collections;
using UnityEngine;


public class BasicBall : MonoBehaviour
{
    [SerializeField] protected float velocity = 1.5f;

    protected SpriteRenderer spriteRenderer;

    protected ParticleSystem particles;

    protected Rigidbody2D rb;

    protected BoxCollider2D boxCollider;

    public Action<BasicBall> AfterHit;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        particles = GetComponent<ParticleSystem>();

        rb = GetComponent<Rigidbody2D>();

        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Shoot(Vector3 direction)
    {
        rb.velocity = direction * velocity;
    }

    public void SetInHandMode()
    {
        rb.isKinematic = true;

        particles.Pause();

        boxCollider.enabled = false;
    }

    public void SetActiveMode()
    {
        rb.isKinematic = false;

        particles.Play();

        boxCollider.enabled = true;
    }

    public void SetPosition(Vector3 position)
    {
        rb.position = position;        
    }

    public void SetRenderer(bool enabled)
    {
        spriteRenderer.enabled = enabled;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AfterHit?.Invoke(this);

        gameObject.SetActive(false);
    }
}
