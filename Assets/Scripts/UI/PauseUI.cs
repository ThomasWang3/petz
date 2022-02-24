using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author(s): Thomas Wang
public class PauseUI : MonoBehaviour {
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private Button buttonObject;
    [SerializeField] private bool paused = false;
    [SerializeField] private Text pausedText;

    public bool IsPaused() {
        return paused;
    }

    // Update is called once per frame
    public void Pause() {
        if (!paused) {
            pauseUI.SetActive(true);
            buttonObject.gameObject.SetActive(false);
            Time.timeScale = 0;
            paused = true;
        } else {
            pauseUI.SetActive(false);
            buttonObject.gameObject.SetActive(true);
            Time.timeScale = 1;
            paused = false;

        }
    }

    public void Win() {
        pauseUI.SetActive(true);
        pausedText.gameObject.SetActive(false);
        Time.timeScale = 0;
        paused = false;
    }

    public void Quit() {
        Application.Quit();
    }
}