using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaceshipMoveMent : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bullet;
    public Transform shootPos;

    public float maxVelocity = 3;
    public float rotationSpeed = 3;
    float shootCooldown;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player to look at mouse
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        // Player input
        //float yAxis = Input.GetAxis("Vertical");
        //float xAxis = Input.GetAxis("Horizontal");
        float yAxis = 1;
        ThrustForward(yAxis);

        if (shootCooldown < 0)
        {
            Instantiate(bullet, shootPos.position, transform.rotation);
            shootCooldown = 0.20f;
        }
        else
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);

    }

    void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;

        rb.AddForce(force);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            

        }
    }
}
