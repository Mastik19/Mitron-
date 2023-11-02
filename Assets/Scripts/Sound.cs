
using UnityEngine;
using UnityEngine.Audio;


[System.Serializable]
public class Sound 
{
    public string name;
    public float volume;
    public AudioClip clip;
    public float pitch;
    public bool isLoop =false;

    public AudioSource source;

    public AudioMixerGroup mixer;

}
