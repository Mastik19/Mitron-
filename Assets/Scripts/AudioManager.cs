using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

   

    void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = s.mixer;
            s.source.loop = s.isLoop;


        }

        PlaySound("MainTheme");

    }

    public void PlaySound(string sound)
    {

        Sound s = Array.Find(sounds, item => item.name == sound);


        
       
            s.source.Play();
       

    }


    public void PauseSound(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        s.source.Pause();


    }

    public void StopSound(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        s.source.Stop();


    }


   
}
