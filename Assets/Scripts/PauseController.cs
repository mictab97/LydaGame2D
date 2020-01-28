using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject helpPanel;

    public void PauseGame() 
    {
        pausePanel.SetActive(true);
        //helpPanel.SetActive(false);
        Time.timeScale = 0f;
    }
    
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        helpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void HelpPanel()
    {
        pausePanel.SetActive(false);
        helpPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
