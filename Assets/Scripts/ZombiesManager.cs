using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesManager : MonoBehaviour
{
    int index;
     void Start()
    {
        index = 0;
        foreach(Transform z  in transform)
        {
            z.gameObject.name = ""+ index;
            index++;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
