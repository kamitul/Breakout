using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDestroyerSkill : MonoBehaviour
{

    public void PreformSkill()
    {
        GameObject[] bricksOnMap = FindObjectOfType<MapGenerator>().Data.bricksOnMap.ToArray();
        for (int i = 0; i < 40; i += 4)
        {
            float prevHealth = bricksOnMap[i].GetComponent<Brick>().Data.HP;
            bricksOnMap[i].GetComponent<Brick>().Data.HP -= 30f;
        }
    }
}
