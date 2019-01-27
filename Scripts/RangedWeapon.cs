using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public float offset;
    public Transform shotPoint;
    public GameObject Shot;

    private float timeBtwShots;
    public float StartTimeBtwShots;
    private void Update()
    {
        
    
    Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
       
        if(timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(Shot, shotPoint.position, transform.rotation);
                timeBtwShots = StartTimeBtwShots;
            }
            
        }
        else { timeBtwShots -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Shot, shotPoint.position, transform.rotation);

        }
     }
}
