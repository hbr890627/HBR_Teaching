using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 500f;


    private Rigidbody2D rigidbody2;
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var movement = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movement * speed * Time.deltaTime, 0, 0);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody2.velocity.y) < 0.01)
        {
            rigidbody2.AddForce(Vector3.up * jumpForce);
        }

    }
}
