using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Rigidbody2D rb;
    public Animator animator;

    // Basic movement
    public float horizontalMove = 0f;
    public float runSpeed = 40;
    bool jump = false;
    public bool canMove = true;
    



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement buttons
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            //animator.SetBool("IsJumping", true);
        }

        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    }


    private void FixedUpdate()
    {
        // Move character
        if (canMove != false)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
        else
        {
            controller.Move( 0, false, false);
            jump = false;
        }
        

    }

    public void OnLanding()
    {
       //animator.SetBool("IsJumping", false);
    }
}
    

