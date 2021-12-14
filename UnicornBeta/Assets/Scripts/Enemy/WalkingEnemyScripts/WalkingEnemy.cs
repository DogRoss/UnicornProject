using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour
{ 
    Rigidbody2D rb;
    Vector2 direction;
    public bool isFacingRight;
    public float speed = 100;
    public int currentEnemyHealth = 1;
    bool damaged;
    bool isDead;



    
    public void SwitchDirection()
    {
        direction *= -1;

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
    void Start()
    {
        if (isFacingRight)
        {
            direction = new Vector2(1, 0);
        }
        else
        {
            direction = new Vector2(-1, 0);
        }

        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        damaged = false;
        if(isDead == true)
        {
            this.gameObject.SetActive(false);


            //Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            SwitchDirection();
        }
        //if (collision.collider.CompareTag("Player"))
        //{
        //    SwitchDirection();
        //}
        if (collision.collider.CompareTag("PlayerDamage"))
        {
            TakeDamage(currentEnemyHealth);
        }
    }
}