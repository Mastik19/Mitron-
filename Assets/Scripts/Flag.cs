using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Flag : MonoBehaviour
{
     Animator animWeapons;
    public bool isCompleted;
     public Slider slider;
    float value;
   
   


    private void Start()
    {
        value = 0;
        isCompleted = false;
        animWeapons = GameObject.FindGameObjectWithTag("WeaponsHolder").GetComponent<Animator>();
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("LoadFlag");
            animWeapons.SetBool("isLoading", true);

        }
    }

    private void OnTriggerStay(Collider other)
    {

        value += 0.005f;
        slider.value = value;

        if (slider.value >= 1)
        {
            isCompleted = true;
            animWeapons.SetBool("isLoading", false);
            FindObjectOfType<AudioManager>().StopSound("LoadFlag");
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<AudioManager>().StopSound("LoadFlag");
        animWeapons.SetBool("isLoading", false);
        

    }

    


}
