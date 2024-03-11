using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    public Button pauseButton;
    public GameObject screenSetting;
    void Start()
    {
        
    }

    void Update()
    {
        pauseButton.onClick.AddListener(() => pauseGame());
    }

    private void pauseGame()
    {
        Time.timeScale = 0;
        screenSetting.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        screenSetting.SetActive(false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        resumeGame();
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
