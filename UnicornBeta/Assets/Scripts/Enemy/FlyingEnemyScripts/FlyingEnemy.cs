using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    public bool isFacingRight;
    public float speed;
    int currentEnemyHealth;
    bool damaged;
    bool isDead;

    private void Awake()
    {
        currentEnemyHealth = 20;
    }
    public void TakeDamage(int damage)
    {
        damaged = true;
        currentEnemyHealth -= damage;
        if (currentEnemyHealth <= 0)
        {
            isDead = true;
        }
    }
    public void SwitchDirection()
    {
            direction = Vector2.Reflect(direction, Vector2.up);
    }
    public void SwitchDirectionWall()
    {
            direction = Vector2.Reflect(direction, new Vector2(-1, 0).normalized);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(1, -1).normalized;
    }
    private void Update()
    {
        damaged = false;
        if (isDead == true)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ceiling"))
        {
            SwitchDirection();
        }
        if (collision.collider.CompareTag("Wall"))
        {
            SwitchDirectionWall();
        }
        if (collision.collider.CompareTag("Ground"))
        {
            SwitchDirection();
        }
        if (collision.collider.CompareTag("PlayerDamage"))
        {
            TakeDamage(currentEnemyHealth);
        }
        if (collision.collider.CompareTag("Player"))
        {
            SwitchDirectionWall();
        }
    }
}
