using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameWeapon : MonoBehaviour
{
    public GameObject[] weaponsModels;
   
    public static int currentIndex;

   

    private void Awake()
    {
        currentIndex = PlayerPrefs.GetInt("SelectedWeapon", 0);

       foreach(GameObject g in weaponsModels)
        {
            g.SetActive(false);
        }

        weaponsModels[currentIndex].SetActive(true);

       
    }
}
