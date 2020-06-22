using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleMapBrickSpawner : BrickSpawner
{
    public TriangleMapBrickSpawner(MapData sentMapData, BrickSetter brickSetter) : base(sentMapData, brickSetter)
    {

    }

    public override void SpawnMap()
    {
        for (int i = mapData.mapDimession.mapHeight; i > 0; --i)
        {
            for (int j = i; j < mapData.mapDimession.mapWidth - i; ++j)
            {
                CreateBrick(i, j);
            }
        }
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

        position.x = j + j * 0.1f - mapData.mapDimession.mapWidth / 2f;
        position.y = i + 3f / mapData.mapDimession.mapHeight;
        position.z = 15;
        return position;
    }
}
