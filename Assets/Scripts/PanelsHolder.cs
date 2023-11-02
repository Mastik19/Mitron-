using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsHolder : MonoBehaviour
{
    public GameObject[] weaponsPanels;

    public void ResetPanels()
    {
        foreach(GameObject p in weaponsPanels)
        {
            p.SetActive(false);
        }
    }
}
