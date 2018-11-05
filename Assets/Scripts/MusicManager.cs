using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    public void ChangeVolume(float volumeValue) {
        audioSource.volume = volumeValue;
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    private void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    private void OnLevelWasLoaded(int level) {
        AudioClip currentLevelMusic = levelMusicChangeArray[level];

        if (currentLevelMusic && currentLevelMusic != audioSource.clip) {
            audioSource.clip = currentLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

}
