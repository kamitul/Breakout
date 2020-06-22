using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

public enum MapShape
{
    RECTANGLE,
    TRIANGLE,
    CRICLE,
    HEXAGONAL,
    RANDOM,
}

[System.Serializable]
public struct MapDimession
{
    [Range(0, 20)]
    public int mapWidth;
    [Range(0, 10)]
    public int mapHeight;
}

[System.Serializable]
public class MapData
{
    [Header("Shape of bricks blocks on map")]
    [HideInInspector]
    public MapShape mapShape;

    [Header("Bricks to spawn")]
    public GameObject[] bricksPrefab;

    [Header("Parrent object for grouping bricks into single pool")]
    public Transform brickPool;

    [Header("Map dimession : Rec, Quad, Triangle, Hex")]
    [Tooltip("Doesn't work with Circle Map")]
    [HideInInspector]
    public MapDimession mapDimession;

    [Header("Map radius: Circle")]
    [HideInInspector]
    public int radius;

    [HideInInspector]
    public float mapOffsetFactor;

    [HideInInspector]
    public GameObject localBrick;

    public List<GameObject> bricksOnMap = new List<GameObject>();
}

public class MapGenerator : MonoBehaviour
{

    [Header("Set parameters for built-in map generator")]
    [SerializeField]
    private MapData data = new MapData();

    [SerializeField]
    private BrickSpawner brickSpawner = default;

    [SerializeField]
    private BrickSetter brickSetter = default;

    [SerializeField]
    private LevelsData levelsData = default;

    public MapData Data
    {
        get
        {
            return data;
        }
    }

    private void Awake()
    {
        BuildMap();
    }

    public void BuildMap()
    {
        if(DataCollector.Instance == null)
        {
            GenerateMap();
            return;
        }
        Action act = DataCollector.Instance.LoadData ? new Action(LoadMap) : new Action(GenerateMap);
        act.Invoke();
    }

    public void GenerateMap()
    {
        ResetSpawner();
        switch (data.mapShape)
        {
            case MapShape.RECTANGLE:
                brickSpawner = new RectangleMapBrickSpawner(Data, brickSetter);
                brickSpawner.SpawnMap();
                break;
            case MapShape.CRICLE:
                brickSpawner = new CircleMapBrickSpawner(Data, brickSetter);
                brickSpawner.SpawnMap();
                break;
            case MapShape.TRIANGLE:
                brickSpawner = new TriangleMapBrickSpawner(Data, brickSetter);
                brickSpawner.SpawnMap();
                break;
            case MapShape.HEXAGONAL:
                brickSpawner = new HexagonalMapBrickSpawner(Data, brickSetter);
                brickSpawner.SpawnMap();
                break;
            case MapShape.RANDOM:
                brickSpawner = new RandomMapBrickSpawner(Data, brickSetter);
                brickSpawner.SpawnMap();
                break;
        }
        CalculateMaxPoints();
    }

    private void LoadMap()
    {
        SaveData savedData = LoadController.GetSaveData();
        if (savedData != null)
        {
            brickSpawner = new LoadMapBrickSpawner(Data, brickSetter);
            (brickSpawner as LoadMapBrickSpawner).SetSavedData(savedData);
            brickSpawner.SpawnMap();
            CalculateMaxPoints();
        }
    }

    private void CalculateMaxPoints()
    {
        int counter = 0;
        for (int i = 0; i < data.bricksOnMap.Count; ++i)
        {
            counter += data.bricksOnMap[i].GetComponent<Brick>().Data.Points;
        }
        GameManager.Instance.GameData.MaxPoints = counter;
    }

    public void ResetSpawner()
    {
        data.bricksOnMap.ForEach(x => { if (x) { Destroy(x); } });
        data.bricksOnMap.Clear();
        MapShape[] shapeArray = levelsData.LevelData[GameManager.Instance.GameData.Level].Item2;
        data.mapShape = shapeArray[UnityEngine.Random.Range(0, shapeArray.Length - 1)];
        data.mapDimession.mapWidth = levelsData.LevelData[GameManager.Instance.GameData.Level].Item1.mapWidth;
        data.mapDimession.mapHeight = levelsData.LevelData[GameManager.Instance.GameData.Level].Item1.mapHeight;
    }
}
