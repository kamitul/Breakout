using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public struct UIData
{
    public Dictionary<int, bool> mapTypeEnabledDictionary;
    public Dictionary<int, bool> brickTypeEnabledDictionary;
    public int difficultyValue;
    public int counter;
}

[RequireComponent(typeof(UIData))]
public class OptionsUIManager : MonoBehaviour
{
    [SerializeField]
    private UIData uiData = default;

    [SerializeField]
    private Toggle[] mapTypeToggle = default;

    [SerializeField]
    private Slider difficultySlider = default;

    private void Awake()
    {
        uiData.mapTypeEnabledDictionary = new Dictionary<int, bool>();
        uiData.brickTypeEnabledDictionary = new Dictionary<int, bool>();
        uiData.difficultyValue = 0;
        uiData.counter = 0;
    }

    public void CollectDataFromUI()
    {
        foreach (Toggle toggle in mapTypeToggle)
        {
            uiData.mapTypeEnabledDictionary.Add(uiData.counter, toggle.isOn);
            uiData.counter++;
        }

        uiData.counter = 0;
        uiData.difficultyValue = (int)difficultySlider.value;
    }

    public int GetDifficultyValue()
    {
        return uiData.difficultyValue;
    }

    public UIData GetData()
    {
        return uiData;
    }

}
