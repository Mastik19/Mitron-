using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWeapon : MonoBehaviour
{
    int currentindex;
    public GameObject[] weaponsObjects;
    void Start()
    {
        currentindex = PlayerPrefs.GetInt("SelectedWeapon", 0);

        foreach(GameObject weapon in weaponsObjects)
        {
            weapon.SetActive(false);

        }

        weaponsObjects[currentindex].SetActive(true);

    }

    
}
