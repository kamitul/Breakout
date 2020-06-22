using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class BrickState
{
    public BrickData BrickData;
    public Vector3 Position;

    public BrickState(BrickData data, Vector3 position)
    {
        this.BrickData = data;
        this.Position = position;
    }
}

[System.Serializable]
public class SaveData
{
    public BrickState[] Bricks;
    public int[] Points;
    public int Lifes;
    public int Level;
}

public class SaveController : MonoBehaviour
{
    [SerializeField]
    private MapGenerator mapGenerator = default;

    private void OnEnable()
    {
        InputController.EscapeClicked += SaveGame;
        GameManager.Instance.GameData.DataChanged += CheckSave;
    }

    private void CheckSave(GameData obj)
    {
        if (obj.Lifes <= 0)
            File.Delete(Application.persistentDataPath + "/game_state.json");
    }

    private void OnDisable()
    {
        InputController.EscapeClicked -= SaveGame;
        GameManager.Instance.GameData.DataChanged -= CheckSave;
    }

    private void SaveGame()
    {
        SaveData savedData = new SaveData();
        List<BrickState> brickStates = new List<BrickState>();
        for (int i = 0; i < mapGenerator.Data.bricksOnMap.Count; ++i)
        {
            if (mapGenerator.Data.bricksOnMap[i])
                brickStates.Add(new BrickState(mapGenerator.Data.bricksOnMap[i].GetComponent<Brick>().Data, mapGenerator.Data.bricksOnMap[i].transform.position));
        }
        savedData.Bricks = brickStates.ToArray();
        savedData.Points = GameManager.Instance.GameData.PointsCollected.ToArray();
        savedData.Lifes = GameManager.Instance.GameData.Lifes;
        savedData.Level = GameManager.Instance.GameData.Level;
        string json = JsonUtility.ToJson(savedData);

        File.WriteAllText(Application.persistentDataPath + "/game_state.json", json);
    }

    public void SaveScore()
    {
        CSVReader.AddScoreToCSV(Application.persistentDataPath + "/points.csv", GameManager.Instance.GameData.PlayerName, GameManager.Instance.GameData.PointsCollected.Sum());
    }
}
