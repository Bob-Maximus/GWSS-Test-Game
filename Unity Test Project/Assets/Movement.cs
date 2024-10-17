using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool grounded;

    public float speed;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "ground")
        {
            grounded = false;
        }
    }

    void MovementInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } 
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.velocity = (Vector2.up * jumpForce) + rb.velocity;
        }
    }
}
