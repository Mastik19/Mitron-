using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameSceneData : MonoBehaviour
{
    public WeaponData[] weaponDataArray;
  
    public WeaponData loadedWeaponData;
    private bool isUpdated;
    int currentTime;
    string weaponName;
    int weaponIndex;
    int zombiesKilled;
    private void Start()
    {
        weaponIndex = PlayerPrefs.GetInt("SelectedWeapon", 0);
        weaponName = weaponDataArray[weaponIndex].name;
        currentTime = PlayerPrefs.GetInt("StageTime", 1);
    }





    private void Update()
    {
        if (CanvasManager.isGameOver && !isUpdated)
        {
            zombiesKilled = CanvasManager.zombiesKilled;
            UpdateGameData(weaponName, currentTime, zombiesKilled);

            isUpdated = true;

        }
    }






        public void UpdateGameData(string weaponName, int timeStage,int zombiesKilled)
        {
        foreach (WeaponData weapon in weaponDataArray)
        {
            if (weapon.name == weaponName)
            {
                if (File.Exists(Application.dataPath + "/" + weaponName))
                {
                     string jsonDataSave = File.ReadAllText(Application.dataPath + "/" + weaponName);
                    loadedWeaponData = JsonUtility.FromJson<WeaponData>(jsonDataSave);

                }
                else
                {
                    // Initialize with default data if the file doesn't exist
                    loadedWeaponData = new WeaponData();
                }



                switch (timeStage)
                {
                    case 1:
                        
                        if (zombiesKilled > loadedWeaponData.time1)
                        {
                            loadedWeaponData.time1 = zombiesKilled;
                        }
                        break;

                    case 5:
                        
                        if (zombiesKilled > loadedWeaponData.time5)
                        {
                            loadedWeaponData.time5 = zombiesKilled;
                        }
                        break;

                    case 10:
                        
                        if (zombiesKilled > loadedWeaponData.time10)
                        {
                            loadedWeaponData.time10 = zombiesKilled;
                        }
                        break;
                    default:
                        Debug.LogError("Invalid time stage");
                        break;
                }



                // Save the updated data to a JSON file
                string jsonData = JsonUtility.ToJson(loadedWeaponData);
                File.WriteAllText(Application.dataPath + "/" + weaponName, jsonData);
            }
        }


    }






    
    }

