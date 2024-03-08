using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    public Button Pausebutton;
    public GameObject screenSetting;


    void Start()
    {
        
    }

    void Update()
    {
        Pausebutton.onClick.AddListener(() => pauseGame());
    }

    private void pauseGame()
    {
        Time.timeScale = 0;
        screenSetting.SetActive(true);
    }

    private void resumeGame()
    {
        Time.timeScale = 1;
    }
}
