using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBrick : Brick
{
    public override void DeactivateBrick()
    {
        if (Data.HP <= 0f)
        {
            itemDrop.ItemDrop(Data.LootType, transform.position);
            pointController.IncrementScore(Data.Points);
            Destroy(gameObject);
        }
    }

    public override void VisualizeDamage()
    {
        //Movement
    }
}
