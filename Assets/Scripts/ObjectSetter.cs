using Paddle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSetter : MonoBehaviour, IResetable
{
    [SerializeField]
    private PaddleController paddleController = default;

    [SerializeField]
    private BallController ballController = default;

    public void ResetState()
    {
        paddleController.SetBall(ballController);
    }

    public void SetBall(BallController ball)
    {
        ballController = ball;
    }
}
