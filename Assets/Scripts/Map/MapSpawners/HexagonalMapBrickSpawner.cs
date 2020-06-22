using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonalMapBrickSpawner : BrickSpawner
{
    public HexagonalMapBrickSpawner(MapData sentMapData, BrickSetter brickSetter) : base(sentMapData, brickSetter)
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

        if (j % 2 == 0)
        {
            position.x = i * 1.9f - mapData.mapDimession.mapWidth / 1.1f;
            position.y = j * 0.6f - mapData.mapDimession.mapHeight / 4 + 2f;
        }
        else
        {
            position.x = (i + 0.5f) * 1.9f - mapData.mapDimession.mapWidth / 1.1f;
            position.y = j * 0.6f - mapData.mapDimession.mapHeight / 4 + 2f;
        }

        position.z = 15f;

        return position;
    }

    public override void SpawnMap()
    {
        for (int i = 0; i < mapData.mapDimession.mapWidth; i++)
        {
            for (int j = 0; j < mapData.mapDimession.mapHeight; j++)
            {
                CreateBrick(i, j);
            }
        }
    }
}