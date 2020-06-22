using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemDropController : MonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField]
    private PowerUpData powerUpData = default;

    [SerializeField]
    [Header("Pool for boosters")]
    private Transform dropedItemPool = default;

    [SerializeField]
    [Header("Boosters for ball")]
    private GameObject[] dropItemsBall = default;

    [SerializeField]
    [Header("Life booster")]
    private GameObject[] dropItemLifes = default;

    [SerializeField]
    [Header("Boosters for paddle with")]
    private GameObject[] dropItemPaddleWidth = default;

    [SerializeField]
    [Header("Boosters for paddle speed")]
    private GameObject[] dropItemPaddleSpeed = default;

    [SerializeField]
    [Header("Score boosters")]
    private GameObject[] dropItemScore = default;

    [SerializeField]
    [Header("All debuffs")]
    private GameObject[] dropItemDebuff = default;

    private Dictionary<LootType, GameObject[]> DropItems = new Dictionary<LootType, GameObject[]>();

    public void ItemDrop(LootType brick, Vector3 brickPosition)
    {
        int percentageToSpawn = UnityEngine.Random.Range(0, 100);
        var powerUp = powerUpData.PowerUpPropabilities.First(x => x.LootType == brick);
        if (percentageToSpawn > 0 && percentageToSpawn < powerUp.Propability)
            SpawnItem(DropItems[brick][UnityEngine.Random.Range(0, DropItems[brick].Length - 1)], brickPosition);
    }

    public void OnAfterDeserialize()
    {
        DropItems.Clear();
        DropItems.Add(LootType.BALL, dropItemsBall);
        DropItems.Add(LootType.DEBUFF, dropItemDebuff);
        DropItems.Add(LootType.SCORE, dropItemScore);
        DropItems.Add(LootType.PADDLEWITH, dropItemPaddleWidth);
        DropItems.Add(LootType.LIFE, dropItemLifes);
        DropItems.Add(LootType.PADDLESPEED, dropItemPaddleSpeed);
    }

    public void OnBeforeSerialize()
    {
    }

    private void SpawnItem(GameObject goToSpawn, Vector3 brickPosition)
    {
        goToSpawn = Instantiate(goToSpawn);
        goToSpawn.transform.SetParent(dropedItemPool);
        goToSpawn.transform.position = brickPosition;
        goToSpawn.GetComponent<Rigidbody>().velocity = new Vector3(0, -0.5f, 0);
        goToSpawn.SetActive(true);
    }
}
