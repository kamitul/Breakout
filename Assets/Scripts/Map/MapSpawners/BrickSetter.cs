using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BrickSetter : MonoBehaviour
{
    public void SetBrick(Vector3 position, ref MapData mapData)
    {
        GameObject brickToSpawn = mapData.bricksPrefab[UnityEngine.Random.Range(0, mapData.bricksPrefab.Length - 1)];
        mapData = brickToSpawn != null ? SetBrickProperties(position, mapData, brickToSpawn) : mapData;
    }

    public void SetBrick(Vector3 position, ref MapData mapData, BrickData brickData)
    {
        GameObject brickToSpawn = mapData.bricksPrefab.ToList().Find(x => x.GetComponent<Brick>().Data.Type == brickData.Type);
        mapData = brickToSpawn != null ? SetBrickProperties(position, mapData, brickToSpawn, brickData) : mapData;
    }

    private MapData SetBrickProperties(Vector3 position, MapData mapData, GameObject brickToSpawn)
    {
        mapData.localBrick = Instantiate(brickToSpawn);
        mapData.localBrick.transform.SetParent(mapData.brickPool);
        mapData.localBrick.transform.position = position;
        mapData.localBrick.SetActive(true);
        return mapData;
    }

    private MapData SetBrickProperties(Vector3 position, MapData mapData, GameObject brickToSpawn, BrickData brickData)
    {
        mapData.localBrick = Instantiate(brickToSpawn);
        SetBrickData(mapData, brickData);
        mapData.localBrick.transform.SetParent(mapData.brickPool);
        mapData.localBrick.transform.position = position;
        mapData.localBrick.SetActive(true);
        return mapData;
    }

    private void SetBrickData(MapData mapData, BrickData brickData)
    {
        mapData.localBrick.GetComponent<Brick>().Data = brickData;
    }
}

