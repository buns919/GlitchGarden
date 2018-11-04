using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip[] levelMusicChangeArray;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    private void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnLevelWasLoaded(int level) {
        AudioClip currentLevelMusic = levelMusicChangeArray[level];
        Debug.Log("Playing clip: " + currentLevelMusic);

        if (currentLevelMusic) {
            audioSource.clip = currentLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
