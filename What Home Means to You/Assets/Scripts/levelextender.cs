using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelextender : MonoBehaviour
{
    public int[] order;
    public GameObject[] sets;
    public Transform genPoint;
    private GameObject clone;
    private float spawn = 0.0f;
    private int counter = 0;

    private void Start()
    {
        clone = Instantiate(sets[0]) as GameObject;
        clone.transform.SetParent(transform);
    }

    private void Update()
    {
        /*if (clone.transform.position.x < genPoint.position.x  && counter < order.Length){
            clone = Instantiate(clone) as GameObject;
            clone.transform.SetParent(transform);
            clone.transform.position = new Vector2(Vector2.right.x * spawn, transform.position.y);
            spawn += sets[#].GetComponent<BoxCollider2D>().size.x;
        }*/
        if (counter < order.Length)
        {
            clone = Instantiate(sets[order[counter]]) as GameObject;
            clone.transform.SetParent(transform);
            clone.transform.position = new Vector2(Vector2.right.x * spawn, transform.position.y);
            spawn += sets[order[counter++]].GetComponent<BoxCollider2D>().size.x;
        }
    }
}
