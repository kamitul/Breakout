using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paddle;

public class PaddleSpeeder : PowerUp, IDropable
{
    [SerializeField]
    private PaddleController paddleController = default;

    public void UpdateGame()
    {
        paddleController.horizontalSpeed += paddleController.horizontalSpeed < 50f ? UnityEngine.Random.Range(5f, 15f) : 0;
        Destroy(gameObject);
    }
}
