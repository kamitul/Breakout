using Paddle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSlower : PowerUp, IDropable
{
    [SerializeField]
    private PaddleController paddleController = default;

    public void UpdateGame()
    {
        if (paddleController.horizontalSpeed > 20f)
        {
            paddleController.horizontalSpeed -= paddleController.horizontalSpeed > 20f ? UnityEngine.Random.Range(5f, 15f) : 0;
        }
        Destroy(gameObject);
    }
}