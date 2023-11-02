using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.CrossPlatformInput;

public class Scope : MonoBehaviour
{
    public GameObject crossHair;
    InputAction scope;
    public static bool isScoped;

    public GameObject scopeEffect;
    public GameObject[] colors;

    public Animator anim;

    public Camera weaponCam;
    public Camera fpsCam;

    void Start()
    {
        isScoped = false;
        scope = new InputAction("Scope", binding: "<mouse>/rightButton");
        scope.Enable();

        foreach(GameObject c in colors)
        {
            c.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Gun.isReloading)
            return;


        if(CrossPlatformInputManager.GetButtonDown("scope"))
        {
           
            isScoped = !isScoped;
            anim.SetBool("isScoping", isScoped);
            if (isScoped)
            {
                StartCoroutine(OnScope());
            }
            else
            {
                OnUnScoped();
            }
        }


    }

    IEnumerator OnScope()
    {
        yield return new WaitForSeconds(0.15f);
        scopeEffect.SetActive(true);
        if(GameWeapon.currentIndex == 1 || GameWeapon.currentIndex ==2)
        {
            colors[0].SetActive(true);
        }
        else if(GameWeapon.currentIndex == 5 || GameWeapon.currentIndex == 6)
        {
            colors[1].SetActive(true);
        }
        
        //fpsCam.cullingMask = fpsCam.cullingMask & ~(1 << 7);
        weaponCam.gameObject.SetActive(false);
        fpsCam.fieldOfView = 20;
        crossHair.SetActive(false);
    }

    void OnUnScoped()
    {
        foreach(GameObject c in colors)
        {
            c.SetActive(false);
        }
        scopeEffect.SetActive(false);
        // fpsCam.cullingMask = fpsCam.cullingMask | (1 << 7);
        weaponCam.gameObject.SetActive(true);
        fpsCam.fieldOfView = 60;
        crossHair.SetActive(true);
    }
}
