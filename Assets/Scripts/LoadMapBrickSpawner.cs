using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMapBrickSpawner : BrickSpawner
{

    public SaveData savedData;

    public LoadMapBrickSpawner(MapData sentMapData, BrickSetter brickSetter) : base(sentMapData, brickSetter)
    {

    }

    public void SetSavedData(SaveData sv)
    {
        savedData = sv;
    }

    public override void SpawnMap()
    {
        for (int i = 0; i < savedData.Bricks.Length; ++i)
        {
            brickSetter.SetBrick(savedData.Bricks[i].Position, ref mapData, savedData.Bricks[i].BrickData);
            mapData.bricksOnMap.Add(mapData.localBrick);
        }
    }
}
