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




    
    public void SwitchDirection()
    {
        direction *= -1;

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
    }
}