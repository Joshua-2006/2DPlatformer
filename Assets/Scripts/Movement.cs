using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    private float vertical;
    private float horizontal;
    public float speed;
    public float drag = 0.9f;
    public float jumpForce;
    public bool grounded;

    public AudioSource a;
    public AudioClip ap;
    public float health = 3;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public GameObject cam;
    public Vector3 offset;
    public Animator overlord;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        overlord = GetComponent<Animator>();
        a = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxis("Horizontal");

        /*float moveInput = Input.GetAxisRaw("Horizontal"); // Get input from the arrow keys or A/D
        Vector2 moveVelocity = new Vector2(moveInput * speed, rb.velocity.y); // Apply horizontal movement to Rigidbody2D velocity
        rb.velocity = moveVelocity;*/

        transform.Translate(Vector2.right * Time.deltaTime * horizontal * speed);
        if(grounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
            a.PlayOneShot(ap);
        }
        if(Input.GetButtonDown("Jump"))
            overlord.SetBool("Grounded", true);
       if(grounded)
        {
            overlord.SetBool("Grounded", false);
        }
        if (horizontal > 0)
        {
            sr.flipX = false;
            overlord.SetBool("Idle", true);
        }
        else if (horizontal < 0)
        {
            sr.flipX = true;
            overlord.SetBool("Idle", true);
        }
        else
            overlord.SetBool("Idle", false);
        
        offset = new Vector3(0, 0, -10);
        cam.transform.position = this.transform.position + offset;

        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            sr.color = Color.red;
            health -= 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            sr.color = Color.red;
            health -= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Potion"))
        {
            health += 1;
            sr.color = Color.green;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        sr.color = Color.white;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        sr.color = Color.white;
    }
    private void OnCollisionExit(Collision collision)
    {
        sr.color = Color.white;
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        overlord.SetBool("Idle", true);
        yield return new WaitForSeconds(10);
        overlord.SetBool("Idle", true);
    }
}
