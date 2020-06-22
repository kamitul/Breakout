using Paddle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileLauncher : Skill
{
    [SerializeField]
    private GameObject projectile = default;

    [SerializeField]
    private PaddleController paddleController = default;

    [SerializeField]
    private List<Projectile> projectiles = default;

    public override void Preform(ref float timer)
    {
        base.Preform(ref timer);
        if (timer >= Data.Cooldown)
        {
            DestroyProjectiles();
            StopAllCoroutines();
            StartCoroutine(ShootProjectile());
            GameManager.Instance.GameData.ActiveSkill = this;
            GameManager.Instance.GameData.ActiveSkill = null;
            timer = 0f;
        }
    }

    private void DestroyProjectiles()
    {
        projectiles.ForEach(x => { if (x) { Destroy(x.gameObject); } });
        projectiles.Clear();
    }

    private IEnumerator ShootProjectile()
    {
        for(int i = 0; i < 5; ++i)
        {
            Vector3 position = paddleController.transform.position + new Vector3(UnityEngine.Random.Range(-1f, 1f), 0.5f, 0f);
            var proj = Instantiate(projectile, position, Quaternion.identity, null);
            proj.SetActive(true);
            var comp = proj.GetComponent<Projectile>();
            comp.Launch(5f);
            projectiles.Add(comp);
            yield return new WaitForSeconds(1f);
        }
    }
}
