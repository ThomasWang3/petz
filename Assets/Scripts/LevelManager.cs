using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// Author(s): Thomas Wang
public class LevelManager : MonoBehaviour {
    public string[] levels;
    public int currentLevelIndex;
    [SerializeField] private GameObject player;
    [SerializeField] private PauseUI pauseUI;
    //GameObject pauseUI = GameObject.Find("PauseUI");


    public void LoadLevelWithIndex(int index) {
        // check for validity of index
        if (index <= levels.Length) {
            pauseUI.Pause();
            SceneManager.LoadSceneAsync(levels[index], LoadSceneMode.Additive);
        }
    }

    public void ReturnToOverworld() {
        SceneManager.UnloadSceneAsync(currentLevelIndex);
        Debug.Log("returning to overworld");
        if (player != null) {
            Debug.Log("reactivating player");
            player.SetActive(true);
        } else {
            Debug.Log("player is null");
            if (player.activeSelf) {
                Debug.Log("active player");
            } else {
                Debug.Log("active player");
            }

        }
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
        SceneManager.LoadScene(currentLevelIndex);
        Time.timeScale = 1;
    }

    public void MultiplayerGame() {
        currentLevelIndex = 6;
        SceneManager.LoadScene(currentLevelIndex);
        Time.timeScale = 1;
    }

    public void LoadMainMenu() {
        LoadLevelWithIndex(0);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}