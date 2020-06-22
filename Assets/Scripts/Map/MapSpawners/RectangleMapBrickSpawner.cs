using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleMapBrickSpawner : BrickSpawner
{
    public RectangleMapBrickSpawner(MapData sentMapData, BrickSetter brickSetter) : base(sentMapData, brickSetter)
    {

    }

    private void CreateBrick(int i, int j)
    {
        Vector3 position = CreatePosition(i, j);
        SetBrick(position);
        mapData.bricksOnMap.Add(mapData.localBrick);
    }

    private Vector3 CreatePosition(int i, int j)
    {
        Vector3 position;

        position.x = i + i * 0.1f - mapData.mapDimession.mapWidth / 2f;
        position.y = j + 3f / mapData.mapDimession.mapHeight;
        position.z = 15;
        return position;
    }

    public override void SpawnMap()
    {
        for (int i = 0; i < mapData.mapDimession.mapWidth; ++i)
        {
            for (int j = 0; j < mapData.mapDimession.mapHeight; ++j)
            {
                CreateBrick(i, j);
            }
        }
    }
}
