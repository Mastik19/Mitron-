using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class Switch : MonoBehaviour
{
    bool isSwitched;

   GameObject weaponHolder;

    public Button[] buttons;
    public GameObject knife;

    public Button knifeButton;
    public Button shootButton;

    public Animator knifeAnim;
    public Transform mainCam;
    public LayerMask zombies;
    void Start()
    {
        weaponHolder = GameObject.FindGameObjectWithTag("WeaponsHolder");
        isSwitched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(CrossPlatformInputManager.GetButtonUp("switch"))
        {

            Switching();
        }

        if(CrossPlatformInputManager.GetButtonUp("knife"))
        {
            KnifeAttack();
        }
        
    }


    public void Switching()
    {
        isSwitched = !isSwitched;

        if (isSwitched)
        {
            foreach (Button b in buttons)
            {
                b.interactable = false;
                b.GetComponent<ButtonHandler>().enabled = false;
                
            }

            knife.SetActive(true);

            knifeButton.gameObject.SetActive(true);
            shootButton.gameObject.SetActive(false);

            weaponHolder.transform.GetChild(PlayerPrefs.GetInt("SelectedWeapon", 0)).gameObject.SetActive(false);

        }

        else
        {
            foreach (Button b in buttons)
            {
                b.interactable = true;
                b.GetComponent<ButtonHandler>().enabled = true;
            }
            knife.SetActive(false);

            knifeButton.gameObject.SetActive(false);
            shootButton.gameObject.SetActive(true);

            weaponHolder.transform.GetChild(PlayerPrefs.GetInt("SelectedWeapon", 0)).gameObject.SetActive(true);
        }

        
    }

    public void KnifeAttack()
    {

        knifeAnim.SetBool("isAttacking", true);
        Collider[] zombiesColliders = Physics.OverlapSphere(mainCam.position, 7, zombies);
        if(zombiesColliders != null)
        {
            foreach(Collider zombie in zombiesColliders)
            {
                zombie.GetComponent<Animator>().SetTrigger("damage");
                zombie.GetComponent<Zombie>().TakeDamage(50);
                FindObjectOfType<AudioManager>().PlaySound("ZombieHurt");
            }

            FindObjectOfType<AudioManager>().PlaySound("KnifeAttack");
        }
    }
}
