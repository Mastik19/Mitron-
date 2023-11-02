using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchWeapon : MonoBehaviour
{
    public int selectedWeapon;
    

    InputAction switching;
    void Start()
    {
        selectedWeapon = 0;

        foreach(Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }

        transform.GetChild(selectedWeapon).gameObject.SetActive(true);

        switching = new InputAction("Scroll", binding: "<Mouse>/scroll");
        switching.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        float scrollValue =  switching.ReadValue<Vector2>().y;

        int previous = selectedWeapon;


        if(scrollValue > 0)
        {

            if(selectedWeapon >= transform.childCount)
            {
                selectedWeapon = 0;
            }
           

            selectedWeapon++;

           
        }
        else if(scrollValue <0)
        {
            selectedWeapon--;
            if(selectedWeapon < 0 )
            {
                selectedWeapon = transform.childCount - 1;
            }
        }

        if(previous != selectedWeapon)
        {
            SelectWeapon();
        }



    }

    private void SelectWeapon()
    {
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }

        transform.GetChild(selectedWeapon).gameObject.SetActive(true);

    }
}
