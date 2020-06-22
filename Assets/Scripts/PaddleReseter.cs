using Paddle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleReseter : MonoBehaviour, IResetable
{
    [SerializeField]
    private PaddleController paddleController = default;

    [SerializeField]
    private Collider collider = default;

    [SerializeField]
    private Transform ballParent = default;

    public void ResetState()
    {
        transform.position = new Vector3(0f, -7.05f, 15f);
        paddleController.ParentBall(ballParent, new Vector3(0f, 1f, 0f));
        collider.enabled = true;
    }
}
