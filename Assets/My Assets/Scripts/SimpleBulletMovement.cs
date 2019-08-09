using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBulletMovement : MonoBehaviour
{
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed *= 100;
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed * Time.deltaTime;
    }
}
