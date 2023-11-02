using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopSystem : MonoBehaviour
{
    public GameObject [] weaponsModels;
    public WeaponBluePrint[] weapons;
    public int currentIndex;
  
    public Button buyButton;
    public TextMeshProUGUI coinsText;
    // Start is called before the first frame update
    void Start()
    {
        
        currentIndex = PlayerPrefs.GetInt("SelectedWeapon", 0);
       foreach(GameObject w in weaponsModels)
        {
            w.SetActive(false);
        }

       foreach(WeaponBluePrint g in weapons)
        {
            if(g.price ==0)
            {
                PlayerPrefs.SetInt(g.name, 0);
                g.isLocked = false;
            }
            else
            {
                g.isLocked = PlayerPrefs.GetInt(g.name) == 0 ? true : false;
            }


        }

        weaponsModels[currentIndex].SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    //public void Next()
    //{
    //    weaponsModels[currentIndex].SetActive(false);
    //    currentIndex++;
    //    if (currentIndex == weaponsModels.Length)
    //        currentIndex = 0;

    //    weaponsModels[currentIndex].SetActive(true);

    //    WeaponBluePrint w = weapons[currentIndex];
    //    if (w.isLocked)
    //        return;


    //    PlayerPrefs.SetInt("SelectedWeapon", currentIndex);



    //}

    //public void Previous()
    //{
    //    weaponsModels[currentIndex].SetActive(false);
    //    currentIndex--;
    //    if (currentIndex == -1)
    //        currentIndex = weaponsModels.Length - 1;

    //    weaponsModels[currentIndex].SetActive(true);

    //    WeaponBluePrint w = weapons[currentIndex];
    //    if (w.isLocked)
    //        return;


    //    PlayerPrefs.SetInt("SelectedWeapon", currentIndex);

    //}


    public void UpdateUI ()
    {
        coinsText.text ="" +  PlayerPrefs.GetInt("Coins", 0);

        WeaponBluePrint w = weapons[currentIndex];

        if (!w.isLocked)
        {

            buyButton.gameObject.SetActive(false);
        }

        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price: " + w.price;

            if (PlayerPrefs.GetInt("Coins") < w.price)
            {
                buyButton.interactable = false;
            }
            else
            {
                buyButton.interactable = true;
            }
        }
       




    }


    public void BuyItem()
    {

        WeaponBluePrint w = weapons[currentIndex];

        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - w.price);
        w.isLocked = false;
        PlayerPrefs.SetInt(w.name, 1);

    }


    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
