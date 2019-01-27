using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelextender : MonoBehaviour
{
    public int[] order;
    public GameObject[] sets;
    public Transform genPoint;
    private float spawn = 0.0f;
    private int counter = 1;
    private void Start()
    {
    }
    private void Update()
    {
        /*if (clone.transform.position.x < genPoint.position.x  && counter < order.Length){
            clone = Instantiate(clone) as GameObject;
            clone.transform.SetParent(transform);
            clone.transform.position = new Vector2(Vector2.right.x * spawn, transform.position.y);
            spawn += sets[#].GetComponent<BoxCollider2D>().size.x;
        }*/


        if (counter < order.Length - 1)
        {
            GameObject clone = Instantiate(sets[order[counter]]) as GameObject;
            Transform enddif = sets[order[counter - 1]].transform.Find("End"),
                      startdif = clone.transform.Find("Start");
            float lol = (enddif.position.y - sets[order[counter - 1]].transform.position.y);
            float lo1 = (startdif.transform.position.y - clone.transform.position.y);
            clone.transform.SetParent(transform);
            clone.transform.position = new Vector2(Vector2.right.x * spawn, lol - lo1);// y = genPoint.position.y
            spawn += (sets[order[counter]].GetComponent<BoxCollider2D>().size.x * sets[order[counter++]].transform.lossyScale.x) / 2 + (sets[order[counter]].GetComponent<BoxCollider2D>().size.x * sets[order[counter]].transform.lossyScale.x) / 2;
        }
    }
}
