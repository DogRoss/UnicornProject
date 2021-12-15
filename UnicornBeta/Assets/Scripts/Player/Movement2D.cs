
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;




[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Movement2D : MonoBehaviour
{

    Rigidbody2D rb;

    Vector2 direction;

    Animator anim;
    SpriteRenderer rend;

    public float speed = .1f;

    public float jumpHeight = 10f;

    bool inAir = false;
    bool rightMoving = false;
    bool leftMoving = false;

    void Start()
    {
        direction = new Vector2(0, 0);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnMove(InputValue value)
    {
        direction.x = value.Get<float>();
        anim.SetBool("isMoving", true);
    }

    private void OnJump(InputValue value)
    {
        Debug.Log("Jump");

        if (inAir == false)
        {
            rb.AddForce(new Vector2(0, 1 * jumpHeight), ForceMode2D.Impulse);
            inAir = true;
        }

    }

    private void OnAttack()
    {
        anim.SetTrigger("isAttacking");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) //if on ground, know that we arent jumping or in air
        {
            
            inAir = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (Mathf.Abs(direction.x) == 0f)
            {
                float vertical = rb.velocity.y / 2f;
                float horizontal = rb.velocity.x / 2f;
                rb.velocity = new Vector2(horizontal, vertical);

            }
        }
    }

    private void Update()
    {
        if (direction.x < 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = -Mathf.Abs(transform.localScale.x);
            transform.localScale = newScale;
        }
        if (direction.x > 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = Mathf.Abs(transform.localScale.x);
            transform.localScale = newScale;
        }


        if (Mathf.Abs(direction.x) == 0)
        {
            anim.SetBool("isMoving", false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vertical = rb.velocity.y;
        float horizontal = direction.x * speed;

        if (Mathf.Abs(direction.x) > 0f)
        {
            rb.velocity = new Vector2(horizontal, vertical);
        }
        
    }
}