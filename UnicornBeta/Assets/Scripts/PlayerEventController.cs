using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerEventController : MonoBehaviour
{

    public int currentHealth = 0;
    public int maxHealth = 10;
    public float launchSpeed = 10f;
    public UIPlayerHealth healthBar;
    public static bool isDead;

    Rigidbody2D rb;

    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    
    private void TakeDamage()
    {
        Debug.Log("takeDamage");

        currentHealth -= 1;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }

    public void Update()
    {
        if(isDead == true)
        {
            anim.SetBool("isDying", true);
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enterCollide");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("collidedEnemy");
            if(collision.transform.position.x > transform.position.x)
            { //launch up-left
                Vector2 upLeft = new Vector2(-launchSpeed, launchSpeed);
                rb.AddForce(upLeft, ForceMode2D.Impulse);
            }
            if (collision.transform.position.x < transform.position.x)
            { //launch up-right
                Vector2 upRight = new Vector2(launchSpeed, launchSpeed);
                rb.AddForce(upRight, ForceMode2D.Impulse);
            }
            TakeDamage();
        }
    }

}
