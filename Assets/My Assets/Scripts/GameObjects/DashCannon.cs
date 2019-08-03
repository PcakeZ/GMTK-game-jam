using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCannon : MonoBehaviour
{
    public GameObject dashEffect;
    public GameObject player;
    public Rigidbody2D rb;

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private float direction;
    private float dashCurrentCooldown = 0;
    public float playerGravity;
    private bool canDash;


    // Start is called before the first frame update
    void Start()
    {
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Dash move
        if (canDash == false && dashCurrentCooldown <= 0)
        {
            if (Input.GetKey(KeyCode.X))
            {
                rb.velocity = Vector2.zero;
                rb.velocity = Vector2.down * 0.5f;
                rb.gravityScale = 0;
                dashTime = startDashTime;
                canDash = true;
            }
        }

        if (canDash == true)
        {
            Dash();
        }
    }


    void Dash()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = 1;
            Instantiate(dashEffect, transform.position, Quaternion.identity);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 2;
            Instantiate(dashEffect, transform.position, Quaternion.identity);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = 3;
            Instantiate(dashEffect, transform.position, Quaternion.identity);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = 4;
            Instantiate(dashEffect, transform.position, Quaternion.identity);
        }
        else
        {
            if (direction == 1)
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            }
            else if (direction == 2)
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            }
        }

        if (dashTime <= 0)
        {
            canDash = false;
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
            rb.gravityScale = playerGravity;
            dashCurrentCooldown = 1;
        }
        else if (direction != 0)
        {
            dashTime -= Time.deltaTime;
            if (direction == 1)
            {
                rb.velocity = Vector2.left * dashSpeed;
            }
            else if (direction == 2)
            {
                rb.velocity = Vector2.right * dashSpeed;
            }
            else if (direction == 3)
            {
                rb.velocity = Vector2.up * dashSpeed;
            }
            else if (direction == 4)
            {
                rb.velocity = Vector2.down * dashSpeed;
            }
        }
    }

    public void DelayReset()
    {
        dashCurrentCooldown = 0;


        if (canDash == true)
        {
            player.GetComponent<PlayerMovement>().controller.Move(0, false, false);
        }
    }
}
