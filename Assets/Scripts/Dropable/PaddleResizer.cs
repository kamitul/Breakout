using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResizeType
{
    LARGE,
    SMALL
}

public class PaddleResizer : PowerUp, IDropable
{
    [SerializeField]
    private Transform paddleController = default;

    [SerializeField]
    private ResizeType resizeType = default;

    private Vector3 paddleLocalScale = default;

    public void UpdateGame()
    {
        paddleLocalScale = paddleController.localScale;
        switch (resizeType)
        {
            case ResizeType.LARGE:
                paddleLocalScale.x *= UnityEngine.Random.Range(0.5f, 1.5f);
                paddleController.localScale = paddleLocalScale;
                break;
            case ResizeType.SMALL:
                paddleLocalScale.x /= UnityEngine.Random.Range(0.5f, 1.5f);
                paddleController.localScale = paddleLocalScale;
                break;
        }

        Destroy(gameObject);
    }
}
