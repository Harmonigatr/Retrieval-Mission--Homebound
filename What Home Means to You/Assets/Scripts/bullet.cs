using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float lifetime;
    public float speed;
    public float distance;
    public LayerMask whatIsSolid;
    public int damage = 3;

    public GameObject destroyEffect;
    private void Start()
    {
        Invoke("Destroybullet", lifetime);
    }
    private void Update()
    {
      
        transform.Translate(transform.up * speed * Time.deltaTime);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Mob"))
            {
                
                

            }

        }
    }
    void Destroybullet()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



   
}