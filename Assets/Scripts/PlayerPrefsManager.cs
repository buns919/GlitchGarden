using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume(float volume) {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
            return;
        }

        Debug.LogError("Master volume out of range.  Not storing in PlayerPrefs.  Volume: " + volume.ToString());
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 100f);
    }

    public static float GetDifficulty() {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY, 1);
    }

    public static void SetDifficulty(float difficulty) {
        if (difficulty >= 1 && difficulty <=3 ) {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
            return;
        }

        Debug.LogError("Diffculty out of range, must be in 1 - 3.  Difficulty: " + difficulty);
       
    }

    public static void UnlockLevel (int level) {
        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        }
        else {
            Debug.Log("Cannot unlock level: " + level.ToString() + " in PlayerPrefsManager");
        }
    }

    public static bool IsLevelUnlocked(int level) {

        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
            bool isLevelUnlocked = (levelValue == 1);
            return isLevelUnlocked;

        }
        else {
            Debug.LogError("Trying to query level not in build settings");
            return false;
        }
    }
}
