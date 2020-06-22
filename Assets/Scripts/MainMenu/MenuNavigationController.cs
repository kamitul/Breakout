using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class MenuNavigationController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> screens = default;

    public void OpenScreen(string name)
    {
        for (int i = 0; i < screens.Count; ++i)
            screens[i].SetActive(false);
        screens.Find(x => x.name == name).SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
