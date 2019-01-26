using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer SprtRndrr;
    public float speed,
                  groundCheckRadious;
    public LayerMask isGroundedLayer;
    private Rigidbody2D rb2d;
    private float jumpHeight = 5,
                  movement;
    private bool isGrounded,
                 toRight = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SprtRndrr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - groundCheckRadious, transform.position.y - groundCheckRadious),
                     new Vector2(transform.position.x + groundCheckRadious, transform.position.y - groundCheckRadious), isGroundedLayer);

        movement = Mathf.Lerp(rb2d.velocity.x, Input.GetAxis("Horizontal") * speed * Time.deltaTime, Time.deltaTime * 10);
        rb2d.velocity = new Vector2(movement, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb2d.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);

        if ((rb2d.velocity.x < 0 && toRight)||(rb2d.velocity.x > 0 && !toRight)) { 
            toRight = !toRight;
            SprtRndrr.flipX = !SprtRndrr.flipX;
        }
    }
}

