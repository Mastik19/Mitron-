using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public  Slider slider;
    public float life;
    public static int zombiesKilled;
    public GameObject blood;
    public bool isHurt;
   
    public TextMeshProUGUI coinsText;
    public int coinsValue;
  
    Zombie[] zombies;
    Flag[] flags;
    public GameObject addCoins;
    public GameObject gameOverPanel;

    public TextMeshProUGUI flagText;

    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI gunName;
    public TextMeshProUGUI gunFireRate;
    public TextMeshProUGUI gunDamage;
    public TextMeshProUGUI gunRange;

    public GameObject pausePanel;


    public Slider sliderLoading;

    public GameObject loadingScreen;

    public TextMeshProUGUI flagPausePanel;


    float flagAmount;
    public GameObject addFlag;



    public TextMeshProUGUI totalFlagsText;
    int allFlags;


    public TextMeshProUGUI flagsGameOVerText;
    public TextMeshProUGUI zombiesKilledGameOVerText;
    public static bool isGameOver;
    public bool isZombieAttack;
    private void Start()
    {
        isZombieAttack = false;
        isGameOver = false;
        zombiesKilled = 0;
        flagAmount = 0;
        flags = FindObjectsOfType<Flag>();
        zombies = FindObjectsOfType<Zombie>();
        
        isHurt = false;
        life = 1;
        coinsValue = PlayerPrefs.GetInt("Coins", 0);


        allFlags = GameObject.FindGameObjectsWithTag("Flag").Length;
        totalFlagsText.text = "Total" + "\n" + "Flags: " + allFlags.ToString();


       
    }

    public void TakeDamage()
    {
        life -= 0.005f;
        slider.value = life;

        if(life <=0)
        {
            PlayerPrefs.SetInt("Coins", coinsValue);
            GameOver();
        }
    }

    private void Update()
    {

        if(isZombieAttack && !isHurt)
        {
            isZombieAttack = false;
            StartCoroutine(Blood());
        }


        Gun g = FindObjectOfType<Gun>();

        if ( g != null)
        {

            ammoText.text = g.currentAmmo + " / " + g.magazineSize;
            gunName.text = g.name;
            gunDamage.text = "Damage: " + g.damage;
            gunFireRate.text = "Fire Rate: " + g.fireRate + "(RPS)";
            gunRange.text = "Range: " + g.radiusHit + "(m)";


        }
       



        foreach (Zombie z in zombies  )
        {
            if (z != null)
            {
                if (z.isDead)
                {
                    z.isDead = false;
                    StartCoroutine(RewardCoins());
                    coinsValue += 1;
                    zombiesKilled++;
                }


            }
            


        }

        foreach(Flag flag in flags)
        {
            if(flag != null)
            {
                if (flag.isCompleted)
                {
                    flag.isCompleted = false;
                    StartCoroutine(RewardFlags());
                    flagAmount++;
                    
                }


            }
           

        }

        flagText.text = "" + flagAmount;
       
        coinsText.text = "" + coinsValue;

       
    }

    IEnumerator Blood()
    {
        isHurt = true;
        blood.SetActive(true);
        yield return new WaitForSeconds(1);
        blood.SetActive(false);
        isHurt = false;
    }

    IEnumerator RewardCoins()
    {
     
        addCoins.SetActive(true);
        yield return new WaitForSeconds(1);
        addCoins.SetActive(false);
        
    }

    IEnumerator RewardFlags()
    {
        
        addFlag.SetActive(true);
        yield return new WaitForSeconds(1);
        addFlag.SetActive(false);
       
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        FindObjectOfType<AudioManager>().StopSound("MainTheme");
       
        FindObjectOfType<AudioManager>().PlaySound("GameOver");

        Gun[] guns = FindObjectsOfType<Gun>();

        foreach (Gun g in guns)
        {
            g.enabled = false;
        }

        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");

        foreach(GameObject zombie in zombies)
        {
           zombie.SetActive(false);
        }

        flagsGameOVerText.text = "" + flagAmount;

        if(zombiesKilled < 10)
        {
            zombiesKilledGameOVerText.text = "You killed " + zombiesKilled + " Zombies !" + "\n" + "You can do better next Time.";

        }
        else if(zombiesKilled <30)
        {
            zombiesKilledGameOVerText.text = "Not Bad!" +"\n" +  "You killed " + zombiesKilled + " Zombies !" ;
        }
        else
        {
            zombiesKilledGameOVerText.text = "Great job!" + "\n" + "You killed " + zombiesKilled + " Zombies !";

        }


      

       
        
    }


    public void PlayAgain()
    {

        StartCoroutine(LoadGameSceneAsync());

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        flagPausePanel.text = "" + flagAmount;
        pausePanel.SetActive(true);


    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToMenu()
    {
        StartCoroutine(LoadMenuSceneAsync());
    }


    IEnumerator LoadGameSceneAsync()
    {

        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");
        while (!operation.isDone)
        {
            sliderLoading.value = operation.progress;
            yield return null;
        }

    }


    IEnumerator LoadMenuSceneAsync()
    {

        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("MainMenu");
        while (!operation.isDone)
        {
            sliderLoading.value = operation.progress;
            yield return null;
        }

    }


}
