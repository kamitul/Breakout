using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrickType
{
    BLUE,
    BROWN,
    GREY,
    LIGHTBROWN,
    DARK,
    WOOD,
    YELLOW
}

public enum LootType
{
    NOTHING,
    PADDLEWITH,
    PADDLESPEED,
    BALL,
    LIFE,
    SCORE,
    DEBUFF
}

[System.Serializable]
public struct BrickData
{
    public BrickType Type;
    public LootType LootType;
    [Range(0, 100)]
    public float HP;
    [Range(0.9f, 1.1f)]
    public float Bounciness;
    public int Points;
}
