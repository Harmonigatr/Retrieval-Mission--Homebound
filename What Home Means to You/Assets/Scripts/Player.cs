using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int damage = 1,
               Health = 10, 
               armour = 0, 
               shield = 0;
    private SpriteRenderer SprtRndrr;
    public float speed,
                 groundCheckRadious;
    public LayerMask isGroundedLayer;
    private Rigidbody2D rb2d;
    private float jumpHeight = 5,
                  movement;
    private bool isGrounded,
                 toRight = true;
   private bool[] items; //0 oldBlanket, 
                         //2 spade,        //3 cellphone,
                         //5 GOAL,          //4 strainer,
                         //6 slingShot,      
                         //11umbrella,
                        


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SprtRndrr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (items[0] != null && items[0])
            jumpHeight = 10;

        if (items[2] != null && items[2])
            damage = 3;
        if (items[11] != null && items[11])
            shield = 5;
        if (items[4] != null && items[4])
            armour = 3;
        if (items[5] != null && items[5])
            jumpHeight = 10;

        if (transform.position.y <= -20 || Health <= 0) {
            Application.LoadLevel("GameOver");
        }
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
    void OnTriggerEnter2D(Collider2D other)
    {
       


        if (other.gameObject.tag == "Mob")
        {
           Health -= (other.GetComponent<Enemy>().damage-(armour + shield));
        }
    }

}

