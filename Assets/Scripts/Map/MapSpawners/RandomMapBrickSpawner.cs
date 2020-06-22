using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapBrickSpawner : BrickSpawner
{
    public RandomMapBrickSpawner(MapData sentMapData, BrickSetter brickSetter) : base(sentMapData, brickSetter)
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
        position.x = i - mapData.mapDimession.mapWidth / 2f;
        position.y = j + 3f / mapData.mapDimession.mapHeight;
        position.z = 15f;

        return position;
    }

    public override void SpawnMap()
    {
        int width = mapData.mapDimession.mapWidth;
        int height = mapData.mapDimession.mapHeight;
        int barrier = 0;

        for (int i = 0; i < width; i++)
        {
            if (i > 0 && i < mapData.mapDimession.mapWidth / 4)
            {
                barrier++;
            }
            if (i > mapData.mapDimession.mapWidth * 3 / 4 && i < mapData.mapDimession.mapWidth)
            {
                barrier--;
            }
            for (int j = height; j > barrier; --j)
            {
                CreateBrick(i, j);
            }
        }
    }
}