using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public int LevelID;
    public MapShape[] MapShapes;
    public MapDimession MapDimession;
    public int Radius;
}

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelsData", order = 1)]
public class LevelsData : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<Level> levelsData = default;

    private Dictionary<int, Tuple<MapDimession, MapShape[], int>> data = new Dictionary<int, Tuple<MapDimession, MapShape[], int>>();

    public Dictionary<int, Tuple<MapDimession, MapShape[], int>> LevelData { get => data; }

    public void OnAfterDeserialize()
    {
        data.Clear();
        for(int i = 0; i < levelsData.Count; ++i)
        {
            data.Add(levelsData[i].LevelID, new Tuple<MapDimession, MapShape[], int>(levelsData[i].MapDimession, levelsData[i].MapShapes, levelsData[i].Radius));
        }
    }

    public void OnBeforeSerialize()
    {
    }
}
