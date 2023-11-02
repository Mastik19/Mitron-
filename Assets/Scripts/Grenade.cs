using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;
public class Grenade : MonoBehaviour
{
    public Transform mainCam;
    
    public GameObject grenadePrefab;
    public GameObject explosionEffect;

   


    public LayerMask zombieLayer;

    public GameObject trajectoryPointPrefab;
    public int numberOfPoints = 20;
    public float force = 40f;

    private bool isAiming = false;
    private Vector3 initialPosition;
    private Vector3 initialVelocity;
    private GameObject[] trajectoryPoints;

    public TextMeshProUGUI greanadeText;
    int grenadeAmount;


    void Start()
    {


        grenadeAmount = PlayerPrefs.GetInt("Grenades", 5);

        trajectoryPoints = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            trajectoryPoints[i] = Instantiate(trajectoryPointPrefab);
            trajectoryPoints[i].SetActive(false);
        }



    }

    private void Update()
    {

        if (grenadeAmount == 0)
            return;

        if(CrossPlatformInputManager.GetButtonDown("grenade"))
        {
            isAiming = true;
            initialPosition = mainCam.transform.position + new Vector3(1, 1, 1);

        }

        if(CrossPlatformInputManager.GetButtonUp("grenade"))
        {
            isAiming = false;
            StartCoroutine(LaunchGrenade());

            grenadeAmount--;

           
         }

        if (isAiming)
        {
            CalculateTrajectory();
        }

        


        greanadeText.text = "Grenades: " + grenadeAmount;

    }


    private void CalculateTrajectory()
    {
        initialVelocity = (mainCam.transform.forward * force );
        float timeStep = 0.1f;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float time = i * timeStep;
            Vector3 position = initialPosition + (initialVelocity * time) + 0.5f * Physics.gravity * time * time;
            trajectoryPoints[i].transform.position = position;
            trajectoryPoints[i].SetActive(true);
        }
    }




   


    IEnumerator LaunchGrenade()
    {

        GameObject greande = Instantiate(grenadePrefab, mainCam.position + new Vector3(1,1,3), Quaternion.identity);
        greande.GetComponent<Rigidbody>().velocity = initialVelocity * 2;

        for (int i = 0; i < numberOfPoints; i++)
        {
            trajectoryPoints[i].SetActive(false);
        }

        yield return new WaitForSeconds(3);

        Instantiate(explosionEffect, greande.transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().PlaySound("GrenadeExplosion");

        
         Collider[] colliders = Physics.OverlapSphere(greande.transform.position, 5,zombieLayer);
          foreach(Collider c in colliders)
        {

            c.gameObject.GetComponent<Animator>().SetTrigger("death");
            c.GetComponent<Zombie>().isDead = true;
        }


        Destroy(greande);
        Invoke("ConcealExplosion", 5);
        
    }

    public void ConcealExplosion()
    {
        explosionEffect.SetActive(false);
    }
}
