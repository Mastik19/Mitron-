using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
   
    // Update is called once per frame
    void Update()
    {

        if(transform.tag == "Grenade")
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }

        else
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
       


    }
}
