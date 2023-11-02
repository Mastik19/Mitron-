using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Table : MonoBehaviour
{
    private void OnEnable()
    {
        int weaponIndex = PlayerPrefs.GetInt("SelectedWeapon", 0);
        string weaponName = GameObject.FindGameObjectWithTag("WeaponsHolder").transform.GetChild(weaponIndex).name;
        Transform correctWeapon = GameObject.FindGameObjectWithTag("Table").transform.Find(weaponName); // Get the reference transform
        int index = correctWeapon.GetSiblingIndex(); // Get the index according transform
        int timeStage = PlayerPrefs.GetInt("StageTime", 1);

        WeaponData loadedWeaponData = FindObjectOfType<GameDataManager>().loadedWeaponData;

        switch (timeStage)
        {
            case 1:
                index++;
                GameObject.FindGameObjectWithTag("Table").
                    transform.GetChild(index).GetComponentInChildren<TextMeshProUGUI>().text = "" + loadedWeaponData.time1;
                break;
            case 5:
                index += 2;
                GameObject.FindGameObjectWithTag("Table").
                    transform.GetChild(index).GetComponentInChildren<TextMeshProUGUI>().text = "" + loadedWeaponData.time5; ;
                break;
            case 10:
                index += 3;
                GameObject.FindGameObjectWithTag("Table").
                    transform.GetChild(index).GetComponentInChildren<TextMeshProUGUI>().text = "" + loadedWeaponData.time10; ;
                break;



        }

    }
}

