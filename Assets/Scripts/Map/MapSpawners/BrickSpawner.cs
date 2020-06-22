using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BrickSpawner
{
    protected MapData mapData;
    protected BrickSetter brickSetter;

    public BrickSpawner(MapData mapData, BrickSetter brickSetter)
    {
        this.mapData = mapData;
        this.brickSetter = brickSetter;
    }

    public abstract void SpawnMap();

    protected void SetBrick(Vector3 position)
    {
        brickSetter.SetBrick(position, ref mapData);
    }
}
