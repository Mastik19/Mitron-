using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
public class TimeCounter : MonoBehaviour
{
    float seconds;
    int minutes;

    public TextMeshProUGUI secondsText;
    public TextMeshProUGUI minutesText;


   
   

    void Start()
    {
        minutes = PlayerPrefs.GetInt("StageTime", 1);
        switch (minutes)
        {
            case 1:
                minutes = 0;
                break;
            case 5:
                minutes = 4;
                break;
            case 10:
                minutes = 9;
                break;

        }
        seconds = 59;
    }

    // Update is called once per frame
    void Update()
    {
        seconds -=  Time.deltaTime;
        

        if(seconds <= 0)
        {
            seconds = 59;
            minutes--;

            if(minutes < 0)
            {
                timeOver();
            }
        }

        if(seconds <= 10 && minutes ==0)
        {
            //play count sound
            //mark text in red

           // FindObjectOfType<AudioManager>().PlaySound("CountDown");
            secondsText.color = new Color(255, 0, 0, 255);
            minutesText.color = new Color(255, 0, 0, 255);
        }

        minutesText.text = "0" + minutes + ":";
        secondsText.text = "" + (int) seconds;
       

       
        
    }

    public void timeOver()
    {
        FindObjectOfType<CanvasManager>().GameOver();
      
    }

    

   
}
