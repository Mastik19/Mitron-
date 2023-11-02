using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class OnClickWeapon : MonoBehaviour
{
    public GameObject[] weaponsModels;
    public WeaponBluePrint[] weapons;
    int currentIndex;
    public Button buyButton;
    public Button selectButton;
    public TextMeshProUGUI coinsText;

    public GameObject selected;
    public GameObject purchased;
    public void ResetWeapons()
    {
        foreach(GameObject w in weaponsModels)
        {
            w.SetActive(false);
        }
    }


    private void Start()
    {
        currentIndex = PlayerPrefs.GetInt("SelectedWeapon", 0);


        foreach (WeaponBluePrint g in weapons)
        {
            
            if (g.price == 0)
            {
                g.isSelected = true;
                PlayerPrefs.SetInt(g.name, 0);
                g.isLocked = false;
            }
            else
            {
                g.isSelected = false;
                g.isLocked = PlayerPrefs.GetInt(g.name) == 0 ? true : false;
            }
        }
    }


    private void Update()
    {
        coinsText.text = "" + PlayerPrefs.GetInt("Coins", 0);
        for (int i =0; i< weaponsModels.Length;i++)
        {
            if (weaponsModels[i].GetComponent<Rotate>().isActiveAndEnabled)
                    currentIndex = i;
        }


        WeaponBluePrint w = weapons[currentIndex];
        if (!w.isLocked)
        {

            buyButton.gameObject.SetActive(false);
            if((!w.isSelected && w.price != 0) || (w.price ==0 && !w.isSelected ))
            {
                selectButton.gameObject.SetActive(true);
            }

            else
            {
                selectButton.gameObject.SetActive(false);
            }
        }

        else
        {
            selectButton.gameObject.SetActive(false);
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


        if (w.name.Equals("Grenade+5") || w.name.Equals("Grenade+10"))
        {
            PlayerPrefs.SetInt("Grenades", PlayerPrefs.GetInt("Grenades") + int.Parse(w.name.Substring(w.name.IndexOf("+")+1, 2)));
            buyButton.gameObject.SetActive(false);
            StartCoroutine(PurchaseAnimation());
            return;
        }
           

        w.isLocked = false;
        PlayerPrefs.SetInt(w.name, 1);
        PlayerPrefs.SetInt("SelectedWeapon", currentIndex);

    }



    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SelectWeapon()
    {
        for (int i = 0; i < weaponsModels.Length; i++)
        {
            if (weaponsModels[i].GetComponent<Rotate>().isActiveAndEnabled)
                currentIndex = i;
        }

        foreach( WeaponBluePrint weapon in weapons)
        {

            weapon.isSelected = false;
        }

        WeaponBluePrint w = weapons[currentIndex];
        w.isSelected = true;
        PlayerPrefs.SetInt("SelectedWeapon", currentIndex);
        StartCoroutine(SelectAnimation());
    }


    IEnumerator SelectAnimation()
    {
        selected.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        selected.SetActive(false);
    }

    IEnumerator PurchaseAnimation()
    {
        purchased.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        purchased.SetActive(false);
    }


}
