using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    float music;
    public AudioSource backgroundMusic;
    private static readonly string MusicPref = "MusicPref";

    void Start()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        music = PlayerPrefs.GetFloat(MusicPref);
        Debug.Log(music);
        backgroundMusic.volume = music;
    }
}
