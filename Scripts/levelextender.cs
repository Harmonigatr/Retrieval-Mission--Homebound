using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelextender : MonoBehaviour
{
    public int[] miniMapSize,
                 order;
    public GameObject[] sets;
    public Transform genPoint;
    private float spawn = 0.0f;
    public int counter = 1,
                incrementor = 0;
    private void Update()
    {
        /*if (clone.transform.position.x < genPoint.position.x  && counter < order.Length){
            clone = Instantiate(clone) as GameObject;
            clone.transform.SetParent(transform);
            clone.transform.position = new Vector2(Vector2.right.x * spawn, transform.position.y);
            spawn += sets[#].GetComponent<BoxCollider2D>().size.x;
        }*/

        if (counter <= miniMapSize[incrementor])
        {
            GameObject clone = Instantiate(sets[order[counter]]) as GameObject;
            clone.transform.SetParent(transform);
            clone.transform.position = new Vector2(Vector2.right.x * spawn, (sets[order[counter - 1]].transform.Find("End").position.y - sets[order[counter - 1]].transform.position.y) - (clone.transform.Find("Start").transform.position.y - clone.transform.position.y));// y = genPoint.position.y
            spawn += (sets[order[counter]].GetComponent<BoxCollider2D>().size.x * sets[order[counter++]].transform.lossyScale.x) / 2 + (sets[order[counter]].GetComponent<BoxCollider2D>().size.x * sets[order[counter]].transform.lossyScale.x) / 2;
        }
    }
}
