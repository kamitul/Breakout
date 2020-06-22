using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBrick : Brick
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
        if (Data.HP <= 25f)
        {
            StartCoroutine(LowHealth());
        }
    }

    private IEnumerator LowHealth()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        while (true)
        {
            mr.material.SetColor("_EmissionColor", mr.material.color * Mathf.PingPong(Time.time * 2f, 1));
            yield return new WaitForEndOfFrame();
        }
    }
}
