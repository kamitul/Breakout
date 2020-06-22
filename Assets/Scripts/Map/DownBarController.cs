using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class DownBarController : Bound
{
    private void OnCollisionEnter(Collision collision)
    {
        var godBall = collision.collider.GetComponent<GodBall>();
        var duplBall = collision.collider.GetComponent<DuplicationBall>();
        if(godBall || duplBall)
        {
            return;
        }

        var ball = collision.collider.GetComponent<BallController>();
        if (ball)
        {
            GameManager.Instance.LooseLife();
        }
    }
}
