using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelextender : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform set1,
                     set2,
                     cam;
    private bool set = true;
    private float currSpot = 0;

    // Update is called once per frame
    void Update()
    {
        if (currSpot < cam.position.x)
        {
            if (set)
                set1.localPosition = new Vector3(set1.localPosition.x + 30, 0, 10);
            else
                set2.localPosition = new Vector3(set2.localPosition.x + 15, 0, 10);
            currSpot += 15;
            set = !set;
        }
        if (currSpot > cam.position.x + 15)
        {
            if (set)
                set2.localPosition = new Vector3(set2.localPosition.x + 15, 0, 10);
            else
                set1.localPosition = new Vector3(set1.localPosition.x + 30, 0, 10);
            currSpot -= 15;
            set = !set;
        }
    }
}
