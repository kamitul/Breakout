using Paddle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodBall : BallController
{
    private Vector3 prevVelocity;
    public float SpeedMultiplier;

    private void FixedUpdate()
    {
        prevVelocity = ballRigidbody.velocity;
        SpeedMultiplier = 1.5f;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        ChangeVelocity(collision);
        PreformRotation();
    }

    protected new void ChangeVelocity(Collision collision)
    {
        var paddleController = collision.collider.GetComponentInParent<PaddleController>();
        if (paddleController)
        {
            ballRigidbody.velocity = Vector3.Reflect(prevVelocity, collision.contacts[0].normal);
            ballRigidbody.velocity += new Vector3(paddleController.GetMovementValue() * 10f, 0f, 0f);
        }
        var brick = collision.collider.GetComponent<Brick>();
        if (brick)
        { ballRigidbody.velocity = prevVelocity; }
        else
        { ballRigidbody.velocity = Vector3.Reflect(prevVelocity, collision.contacts[0].normal); }
    }
}
