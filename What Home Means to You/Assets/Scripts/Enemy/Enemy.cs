using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //GameObject enemy;
    public int health = 2,damage=1;
   
    

    //when enemy health is x do y
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            health -= other.GetComponent<Player>().damage;



        }
        if (other.gameObject.tag == "project")
        {
            health -= other.GetComponent<bullet>().damage;
        }
    }
}
