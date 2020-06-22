using UnityEngine;
using System.Collections;

public class CircleMapBrickSpawner : BrickSpawner
{
    public CircleMapBrickSpawner(MapData sentMapData, BrickSetter brickSetter) : base(sentMapData, brickSetter)
    {

    }

    public override void SpawnMap()
    {
        for (int y = -mapData.radius; y <= mapData.radius; y++)
        {
            for (int x = -mapData.radius; x <= mapData.radius; x++)
            {
                if (x * x + y * y <= mapData.radius * mapData.radius)
                {
                    CreateBrick(x, y);
                }
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

        position.x = j + j * 0.1f;
        position.y = i + 3f / mapData.radius;
        position.z = 15;
        return position;
    }
}
