using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager instance;
    public WeaponData[] weaponDataArray; // You can populate this array in the Unity Editor

   
    public WeaponData loadedWeaponData;
    int index;
   
  
    int weaponIndex;
   

   

    private void Start()
    {
       
        weaponIndex = PlayerPrefs.GetInt("SelectedWeapon",0);
        
       

       
    }

    private void OnEnable()
    {
       
            LoadGameData();
        
               
    }

    private void LoadGameData()
    {

        foreach(WeaponData wd in weaponDataArray)
        {

            if (File.Exists(Application.dataPath + "/"+ wd.name ))
            {
                string jsonData = File.ReadAllText(Application.dataPath + "/" + wd.name);
                loadedWeaponData = JsonUtility.FromJson<WeaponData>(jsonData);

            }
            else
            {
                // Initialize with default data if the file doesn't exist
                loadedWeaponData = new WeaponData();
            }

          switch(wd.name)
            {
                case "PSR":
                    index = 4;
                    break;
                case "Rifle1":
                    index = 8;
                    break;
                case "Rifle2":
                    index = 12;
                    break;
                case "SMG1":
                    index = 16;
                    break;
                case "SMG2":
                    index = 20;
                    break;
                case "Sniper1":
                    index = 24;
                    break;
                case "Sniper2":
                    index = 28;
                    break;
                case "Shotgun1":
                    index = 32;
                    break;
                case "Shotgun2":
                    index = 36;
                    break;
                case "Pistol1":
                    index = 40;
                    break;
                case "Pistol2":
                    index = 44;
                    break;


                default:
                    index = 4;
                    break;



            }

            index++;
            transform.GetChild(index).GetComponentInChildren<TextMeshProUGUI>().text 
            = loadedWeaponData.time1.ToString();
            index++;
           transform.GetChild(index).GetComponentInChildren<TextMeshProUGUI>().text
            = loadedWeaponData.time5.ToString();
            index++;
            transform.GetChild(index).GetComponentInChildren<TextMeshProUGUI>().text
            = loadedWeaponData.time10.ToString();


        }


      
    }

    

}
