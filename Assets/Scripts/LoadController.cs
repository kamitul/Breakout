using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadController : MonoBehaviour
{
    private static SaveData SavedData;

    private void Awake()
    {
        GameManager.Instance.ResetState();
        LoadData();
        TryToLoadData();
    }

    public void LoadData()
    {
        if (DataCollector.Instance == null)
        {
            return;
        }
        Func<SaveData> act = DataCollector.Instance.LoadData ? new Func<SaveData>(LoadGameState) : new Func<SaveData>(() => { return null; });
        SavedData = act.Invoke();
    }

    private void TryToLoadData()
    {
        SaveData savedData = GetSaveData();
        if (savedData != null)
        {
            GameManager.Instance.GameData.Lifes = savedData.Lifes;
            GameManager.Instance.GameData.Level = savedData.Level;
            GameManager.Instance.GameData.PointsCollected = new List<int>(savedData.Points);
        }
    }

    private SaveData LoadGameState()
    {
        SaveData saveData;
        using (StreamReader stream = new StreamReader(Application.persistentDataPath + "/game_state.json"))
        {
            string json = stream.ReadToEnd();
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        return saveData;
    }

    public static SaveData GetSaveData()
    {
        return SavedData;
    }
}
