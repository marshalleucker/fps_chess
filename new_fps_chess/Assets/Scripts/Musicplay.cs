using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Musicplay : MonoBehaviour
{
    public Slider volumeSlider;
    public GameObject ObjectMusic;
    private float MusicVolume = 1f;
    public AudioSource AudioSource;


    private void Start()
    {
        // Start playing the music
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();
        AudioSource.Play();

        MusicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = MusicVolume;
        volumeSlider.value = MusicVolume;
    }


    public void VolumeUpdater(float volume)
    {
        MusicVolume = volume;
    }
}