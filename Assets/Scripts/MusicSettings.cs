using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MusicSettings : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider SFXSlider;

    public AudioMixer mixer;

    void Start()
    {
        if(PlayerPrefs.HasKey("Master"))
        {
            mixer.SetFloat("Master", PlayerPrefs.GetFloat("Master"));
        }

        if(PlayerPrefs.HasKey("Music"))
        {
            mixer.SetFloat("Music", PlayerPrefs.GetFloat("Music"));
        }

        if (PlayerPrefs.HasKey("SFX"))
        {
            mixer.SetFloat("SFX", PlayerPrefs.GetFloat("SFX"));
        }

    }

    public  void onChangeMaster()
    {
        mixer.SetFloat("Master", masterSlider.value);
        PlayerPrefs.SetFloat("Master", masterSlider.value);
    }

    public void onChangeMusic()
    {
        mixer.SetFloat("Music", musicSlider.value);
        PlayerPrefs.SetFloat("Music", musicSlider.value);
    }

    public void onChangeSFX()
    {
        mixer.SetFloat("SFX", SFXSlider.value);
         PlayerPrefs.SetFloat("SFX", SFXSlider.value);
    }
}
