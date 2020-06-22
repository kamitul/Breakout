using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDestroyer : Skill
{
    [SerializeField]
    private MapGenerator mapGenerator = default;

    public override void Preform(ref float timer)
    {
        base.Preform(ref timer);

        if (timer >= Data.Cooldown)
        {
            GameManager.Instance.GameData.ActiveSkill = this;
            GameManager.Instance.GameData.ActiveSkill = null;
            for (int i = 0; i < mapGenerator.Data.bricksOnMap.Count; i += UnityEngine.Random.Range(2, 3))
            {
                if (mapGenerator.Data.bricksOnMap[i])
                {
                    mapGenerator.Data.bricksOnMap[i].GetComponent<Brick>().TakeDamage(2f);
                }
            }

            timer = 0f;
        }
    }
}
