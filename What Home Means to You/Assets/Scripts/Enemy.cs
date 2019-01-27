using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //GameObject enemy;
    public int health = 2,
               damage = 1,
               timer = 0,
               speed = 250,
               bob = 0;
    private Rigidbody2D rb2d;
    private System.Random direction = new System.Random();

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //when enemy health is x do y
    private void Update()
    {
        if (health <= 0)
            Destroy(this.gameObject);
        if (timer++ == 100)
        {
            timer = 0;
            switch (direction.Next(0, 4))
            {
                case 1://Right
                    bob = 1;
                    break;
                case 2://Left
                    bob = -1;
                    break;
                case 3://Fart
                    bob = 0;
                    break;
            }
        }
        rb2d.velocity = new Vector2(Mathf.Lerp(rb2d.velocity.x, bob * speed * Time.deltaTime, Time.deltaTime * 10), rb2d.velocity.y);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            health -= other.GetComponent<Player>().damage;
        }
    }
}
