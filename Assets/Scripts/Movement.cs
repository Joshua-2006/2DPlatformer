using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vertical;
    public float horizontal;
    public float speed;
    public float drag = 0.9f;
    public float jumpForce;
    public bool grounded;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        float moveInput = Input.GetAxisRaw("Horizontal"); // Get input from the arrow keys or A/D
        Vector2 moveVelocity = new Vector2(moveInput * speed, rb.velocity.y); // Apply horizontal movement to Rigidbody2D velocity
        rb.velocity = moveVelocity;

        if(grounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
