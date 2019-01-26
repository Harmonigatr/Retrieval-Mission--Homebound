using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public float jump;
    public float speed;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadious;
    public LayerMask isGroundedLayer;
    private float jumpHeight = 5;
   
    Rigidbody2D rb;

    Animator anim;


    // Start is called before the first frame update

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      float moveHorizontal = Input.GetAxis("Horizontal");
        float Virt = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }

        Vector2 movement = new Vector2(moveHorizontal,Virt);

       rb2d.AddForce(movement * speed);
    }
}

