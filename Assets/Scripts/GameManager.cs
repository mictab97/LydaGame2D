﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}