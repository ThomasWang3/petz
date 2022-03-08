using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// Author(s): Thomas Wang
public class LevelManager : MonoBehaviour
{
    public string[] levels;
    public int currentLevelIndex;
    //GameObject pauseUI = GameObject.Find("PauseUI");


    public void LoadLevelWithIndex(int index) {
        // check for validity of index
        if (index <= levels.Length) {
            SceneManager.LoadScene(levels[index]);
        }
    }

    public void NextLevel() {
        currentLevelIndex++;
        LoadLevelWithIndex(currentLevelIndex);
        Time.timeScale = 1;
    }
    public void PreviousLevel() {
        currentLevelIndex--;
        LoadLevelWithIndex(currentLevelIndex);
        Time.timeScale = 1;
    }

    public void RestartLevel() {
        LoadLevelWithIndex(currentLevelIndex);
        Time.timeScale = 1;
    }

    public void NewGame() {
        currentLevelIndex = 1;
        LoadLevelWithIndex(currentLevelIndex);
        Time.timeScale = 1;
    }

    public void LoadMainMenu() {
        LoadLevelWithIndex(0);
        Time.timeScale = 1;
    }
}
