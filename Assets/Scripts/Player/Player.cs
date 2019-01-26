using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]

public class Character : MonoBehaviour
{


    public float jump;
    public float speed;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadious;
    public LayerMask isGroundedLayer;


    Rigidbody2D rb;

    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        if (!groundCheck)
        {
            groundCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();

        }
        if (groundCheckRadious <= 0)
        {
            groundCheckRadious = 0.1f;

        }

        anim = GetComponent<Animator>();

        if (!anim)
        {
            Debug.LogError("Animation not working");

        }

        rb = GetComponent<Rigidbody2D>();
        rb.mass = 1.0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.sleepMode = RigidbodySleepMode2D.NeverSleep;
        if (speed <= 0 || speed > 5.0f)
        {

            speed = 5.0f;
        }
        if (jump <= 0 || jump > 10.0f)
            jump = 10.0f;

    }


    // Update is called once per frame
    void Update()
    {
        float moveValue = Input.GetAxisRaw("Horizontal");
        if (groundCheck)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadious, isGroundedLayer);
        }
        if (isGrounded)
        {

            anim.SetBool("grounded", isGrounded);

            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            }
            rb.velocity = new Vector2(moveValue * speed, rb.velocity.y);
        }
        if (anim)
            anim.SetFloat("Movment", Mathf.Abs(moveValue));
        anim.SetBool("Grounded", isGrounded);
    }
}
