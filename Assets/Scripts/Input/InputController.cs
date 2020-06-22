using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class InputController : MonoBehaviour
{

    public static Action ReleaseBall;
    public static Action EscapeClicked;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReleaseBall.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.ExitToMainMenu();
            EscapeClicked.Invoke();
        }
    }
}
