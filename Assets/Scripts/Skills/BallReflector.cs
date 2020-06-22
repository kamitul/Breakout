using Paddle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BallReflector : Skill
{
    [SerializeField]
    private GameObject ball = default;

    [SerializeField]
    private ObjectSetter setter = default;

    public override void Preform(ref float timer)
    {
        base.Preform(ref timer);
        if (timer >= Data.Cooldown && ball.GetComponent<BallController>().IsLanuched)
        {
            StartCoroutine(EnableGodBall());
            GameManager.Instance.GameData.ActiveSkill = this;
            GameManager.Instance.GameData.ActiveSkill = null;
            timer = 0f;
        }
    }

    private IEnumerator EnableGodBall()
    {
        BallController bc = ball.GetComponent<BallController>();
        float force = ball.GetComponent<BallController>().Force;
        float speed = ball.GetComponent<BallController>().Speed;

        bc.enabled = false;
        bc.Force = 200f;
        bc.Speed = 100f;
        GodBall gb = ball.AddComponent<GodBall>();
        gb.SpeedMultiplier = 1.5f;

        ball.GetComponent<Rigidbody>().velocity *= gb.SpeedMultiplier;

        yield return new WaitForSeconds(5f);

        Destroy(gb);
        bc.enabled = true;
        ball.GetComponent<Rigidbody>().velocity /= gb.SpeedMultiplier;
        bc.Force = force;
        bc.Speed = speed;

        setter.SetBall(bc);
    }
}
