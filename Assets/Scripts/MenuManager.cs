using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public Slider slider;
    
    public GameObject loadingGame;
    public GameObject loadingClear;
    public GameObject settingsPanel;

    

    public TextMeshProUGUI coinsText;

    public TMP_Dropdown drop;
    public void PlayGame()

    {

        StartCoroutine(LoadGameSceneAsync());
    }

    public void OpenShop()
    {
        StartCoroutine(LoadShopSceneAsync());

    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }


    IEnumerator LoadShopSceneAsync()
    {

        loadingClear.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Shop");
        while (!operation.isDone)
        {
            slider.value = operation.progress;
            yield return null;
        }

    }


    IEnumerator LoadGameSceneAsync()
    {

        loadingGame.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");
        while( !operation.isDone)
        {
            slider.value = operation.progress;
            yield return null;
        }

    }

    public void ChangeGraphicsQuality()
    {

        QualitySettings.SetQualityLevel(drop.value);

    }


    private void Update()
    {
        coinsText.text = "" + PlayerPrefs.GetInt("Coins", 0);
    }
}
