using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;




[RequireComponent(typeof(Rigidbody2D))]
public class Movement2D : MonoBehaviour
{

    Rigidbody2D rb;

    Vector2 direction;

    public float speed = 1f;

    public float jumpHeight = 10f;

    bool inAir = false;
    bool rightMoving = false;
    bool leftMoving = false;


    // Start is called before the first frame update
    //private void Start()
    //{
    //    
    //
    //}

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnRightMove(InputValue value)
    {

        if (value.Get<float>() > 0f)
        {
            Debug.Log("pressed");
        }
        if (value.Get<float>() == 0f)
        {
            Debug.Log("released");
        }

    }

    private void OnLeftMove(InputValue value) 
    {

        if (value.Get<float>() > 0f)
        {
            Debug.Log("pressed");
        }
        if (value.Get<float>() == 0f)
        {
            Debug.Log("released");
        }


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


            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            inAir = true;
        }


        //rb.AddForce(Vector2.up * 20, ForceMode2D.Impulse);



    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) //if on ground, know that we arent jumping or in air
        {
            inAir = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (rightMoving == true)
        {
            rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        }

        if (leftMoving == true)
        {
            rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        }
    }
}
