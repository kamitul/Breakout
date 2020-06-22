using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WarningPopUp : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject canv;

    private void OnEnable()
    {
        DataCollector.SaveWarning += ShowWarning;
    }

    private void OnDisable()
    {
        DataCollector.SaveWarning -= ShowWarning;
    }

    private void ShowWarning(string obj)
    {
        canv.SetActive(true);
        text.text = obj;
    }
}
