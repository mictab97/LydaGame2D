using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
