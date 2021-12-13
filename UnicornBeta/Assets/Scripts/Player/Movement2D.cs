using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;




[RequireComponent(typeof(Rigidbody2D))]
public class Movement2D : MonoBehaviour
{

    Rigidbody2D rb;

    Vector2 direction;
    Vector2 zeroDirection;

    Vector2 jumpDirection;

    public float speed = 1f;

    public float jumpHeight = 10f;

    bool inAir = false;
    bool isJumping = false;


    // Start is called before the first frame update
    //private void Start()
    //{
    //    
    //
    //}

    void Start()
    {
        zeroDirection = new Vector2(0,0);
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value)
    {
        //Debug.Log("MoveInput");
        direction.x = value.Get<Vector2>().x;

        

        //direction.y = value.Get<Vector2>().y;

    }

    private void OnJump(InputValue value)
    {
        Debug.Log("Jump");

        /*
        if (value.Get<int>() > 0)
        {
            Debug.Log("JumpInitPress");
        }
        if(value.Get<int>() == 0)
        {
            Debug.Log("JumpReleasePress");
        }*/
        
        if (inAir == false)
        {
            //Debug.Log("NowInAir");
            //direction.y = 1;
            ////rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            //rb.velocity += direction * 10f;

            rb.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
            inAir = true;
        }


        //rb.AddForce(Vector2.up * 20, ForceMode2D.Impulse);



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground")) //if on ground, know that we arent jumping or in air
        {
            isJumping = false;
            inAir = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

        //cap speed
        //slowdown to stop  
        //jump\     

        //while (isJumping)
        //{
        //
        //}

        //Debug.Log("VelocityChange");
        
        //rb.velocity = direction * speed;





    }
}
