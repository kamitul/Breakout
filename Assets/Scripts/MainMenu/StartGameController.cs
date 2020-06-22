using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    public void StartGame(int sceneIndex)
    {
        Time.timeScale = 1;
        DataCollector.Instance.SetLoadData(false);
        SceneManager.LoadScene(sceneIndex);
    }

    public void ContinueGame(int sceneIndex)
    {
        Time.timeScale = 1;
        if(DataCollector.Instance.SetLoadData(true))
            SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
