using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class ButtonDetector : MonoBehaviour

{

    public TextMeshProUGUI infotimeText;
    string time = "1";
    int value;
    public Button[] buttons;


    private void Start()
    {
        
    }

    public void selectButton()
    {

        foreach ( Button b in buttons)
        {
            b.transform.GetChild(1).transform.gameObject.SetActive(false);
        }


        time = EventSystem.current.currentSelectedGameObject.name;
    }
    
     
    public void onLoading()
    {
        value = int.Parse(time);
        PlayerPrefs.SetInt("StageTime", value);

        if (value == 10)
        {

            infotimeText.text = "Stage Time: " +"\n"  + time + ":00";
        }
        else
        {
            infotimeText.text = "Stage Time: "+"\n" + "0" + time + ":00";
        }
    }

}
