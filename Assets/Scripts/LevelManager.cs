using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelTime;

    private void Awake() {

    }

    private void Start() {
        if (autoLoadNextLevelTime != 0) {
            Invoke("LoadNextScene", autoLoadNextLevelTime);
        }
    }

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene() {
        SceneManager.LoadScene("01 Start");
    }

    public void LoadGameScene() {
        SceneManager.LoadScene("02 Level_01");
    }

    public void LoadScene(string levelName) {
        SceneManager.LoadScene(levelName);
    }

    public void LoadOptionsScene() {
        SceneManager.LoadScene("01a Options");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
