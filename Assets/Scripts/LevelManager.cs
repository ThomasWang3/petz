using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// Author(s): Thomas Wang
[CreateAssetMenu(fileName = "levelManager", menuName = "LevelManager")]
public class LevelManager : MonoBehaviour
{
    public string[] levels;
    public int currentLevelIndex = 0;
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
    }
    public void PreviousLevel() {
        currentLevelIndex--;
        LoadLevelWithIndex(currentLevelIndex);
    }

    public void RestartLevel() {
        LoadLevelWithIndex(currentLevelIndex);
    }

    public void NewGame() {
        currentLevelIndex = 1;
        LoadLevelWithIndex(currentLevelIndex);
    }

    public void LoadMainMenu() {
        LoadLevelWithIndex(0);
    }
}
