using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// Author(s): Thomas Wang
public class LevelManager : MonoBehaviour {
    public string[] levels;
    public int currentLevelIndex;
    //GameObject pauseUI = GameObject.Find("PauseUI");


    public void LoadLevelWithIndex(int index) {
        // check for validity of index
        if (index <= levels.Length) {
            SceneManager.LoadSceneAsync(levels[index], LoadSceneMode.Additive);
        }
    }

    public void ReturnToOverworld() {
        SceneManager.UnloadSceneAsync(currentLevelIndex);
    }

    public void NextLevel() {
        currentLevelIndex++;
        SceneManager.LoadScene(currentLevelIndex);
        Time.timeScale = 1;
    }
    public void PreviousLevel() {
        currentLevelIndex--;
        SceneManager.LoadScene(currentLevelIndex);
        Time.timeScale = 1;
    }

    public void RestartLevel() {
        SceneManager.LoadScene(currentLevelIndex);
        Time.timeScale = 1;
    }

    public void NewGame() {
        currentLevelIndex = 1;
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void LoadMainMenu() {
        LoadLevelWithIndex(0);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}