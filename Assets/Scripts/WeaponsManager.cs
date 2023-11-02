using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public GameObject[] weapons;
   

    public void ResetWeapons()
    {
        foreach(GameObject w in weapons)
        {
            w.SetActive(false);
        }
      
    }

}
