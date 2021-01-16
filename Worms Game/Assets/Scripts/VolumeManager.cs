using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    public Slider volumeSlider;
    float music;
    int first;
    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        first = PlayerPrefs.GetInt(FirstPlay);

        if (first == 0)
        {
            music = 0.25f;
            volumeSlider.value = music;
            PlayerPrefs.SetFloat(MusicPref, music);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            music = PlayerPrefs.GetFloat(MusicPref);
            volumeSlider.value = music * 100;
            Debug.Log(music);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveSound() 
    {
        PlayerPrefs.SetFloat(MusicPref, ((float)volumeSlider.value / 100));
    }

    public void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus) 
        {
            SaveSound();
        }
    }

    public void UpdateSound()
    {
        backgroundMusic.volume = ((float)volumeSlider.value / 100);
    }
}
