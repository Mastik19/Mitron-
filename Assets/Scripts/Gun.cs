using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityStandardAssets.CrossPlatformInput;
public class Gun : MonoBehaviour
{
    InputAction shoot;
    InputAction reload;
  
    public float impactForce;
   
    public float nextTimeToFire;

    public Transform fpsCam;
   
    public ParticleSystem muzzleFlush;
    public GameObject impactEffect;

   
    public float fireRate;
    public int maxAmmo;
    public int magazineSize;
    public float radiusHit;
    public int damage;


    public int currentAmmo;
    public int gap;

    public static bool isShooting;

    public Animator anim;


    public static bool isReloading;

    // Start is called before the first frame update
    void Start()
    {
       // maxAmmo = 20;
       // magazineSize = 100;
        //fireRate = 10;
        impactForce = 500;
        //radiusHit = 40;
        currentAmmo = maxAmmo;


        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");
        shoot.Enable();


        reload = new InputAction("Reload", binding: "<keyboard>/R");
        reload.Enable();

        nextTimeToFire = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if( CrossPlatformInputManager.GetButtonDown("reload")&& !Scope.isScoped || currentAmmo ==0) //reload.triggered
        {
            StartCoroutine(Reload());

        }
        else if (CrossPlatformInputManager.GetButtonDown("reload") && magazineSize == 0)
        {
            FindObjectOfType<AudioManager>().PlaySound("OutOfAmmo");
            return;
        }

       

      
        if (isReloading)
            return;
            



        isShooting =  CrossPlatformInputManager.GetButton("shoot") ;   //shoot.ReadValue<float>() == 1
        anim.SetBool("isShooting", isShooting);

        if(isShooting && Time.time >= nextTimeToFire)
        {

            nextTimeToFire = Time.time + (1f / fireRate);

            Fire();
        }




    }


    public void Fire()
    {
        currentAmmo--;

        switch(PlayerPrefs.GetInt("SelectedWeapon"))
        {
            case 0:
                FindObjectOfType<AudioManager>().PlaySound("Shoot");
                break;
            case 1:
                FindObjectOfType<AudioManager>().PlaySound("RifleShoot");
                break;
            case 2:
                FindObjectOfType<AudioManager>().PlaySound("RifleShoot");
                break;
            case 3:
                FindObjectOfType<AudioManager>().PlaySound("SMGShoot");
                break;
            case 4:
                FindObjectOfType<AudioManager>().PlaySound("SMGShoot");
                break;
            case 5:
                FindObjectOfType<AudioManager>().PlaySound("SniperShoot");
                break;
            case 6:
                FindObjectOfType<AudioManager>().PlaySound("SniperShoot");
                break;
            case 7:
                FindObjectOfType<AudioManager>().PlaySound("ShotGunShoot");
                break;
            case 8:
                FindObjectOfType<AudioManager>().PlaySound("ShotGunShoot");
                break;
            case 9:
                FindObjectOfType<AudioManager>().PlaySound("PistolShoot");
                break;
            case 10:
                FindObjectOfType<AudioManager>().PlaySound("PistolShoot");
                break;



        }


        muzzleFlush.Play();



        RaycastHit hit;
        if (Physics.Raycast(fpsCam.position, fpsCam.forward, out hit, radiusHit))
        {
            Debug.Log("you hit: " + hit.transform.gameObject);

            

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
                
            }
           
            Zombie z = hit.transform.GetComponent<Zombie>();
            
            if(z != null)
            {

                
                z.TakeDamage(damage);
                FindObjectOfType<AudioManager>().PlaySound("ZombieHurt");
            }


            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
              GameObject impact =  Instantiate(impactEffect, hit.point, impactRotation);
            Destroy(impact, 5);
        }

    }

    IEnumerator Reload()
    {
        isReloading = true;
        anim.SetBool("isReloading", true);
        FindObjectOfType<AudioManager>().PlaySound("Reload");
        yield return new WaitForSeconds(2);
        anim.SetBool("isReloading", false);

        if(currentAmmo==0)
        {
            gap = maxAmmo;
        }
        else
        {
            gap = maxAmmo - currentAmmo;
        }
        
        magazineSize -= gap;
        magazineSize = Mathf.Clamp(magazineSize, 0, 100);
        currentAmmo = maxAmmo;
        isReloading = false;

    }

}
