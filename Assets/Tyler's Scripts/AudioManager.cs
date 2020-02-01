using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public GameObject menuManager;
    public AudioMixer mixer;
    public Slider musicSlider;
    public Slider SFXSlider;


    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music", 0.75f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFX", 0.75f);

    }

    public void SetMusicVolume()
    {
        float sliderValue = musicSlider.value;
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("Music", sliderValue);
    }

    public void SetSFXVolume()
    {
        float sliderValue = SFXSlider.value;
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFX", sliderValue);
    }
}
