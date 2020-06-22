using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Paddle;
using UnityEngine.Video;

public class BallController : MonoBehaviour
{
    [Range(2.5f, 3.5f)]
    public float Speed = 3.25f;

    [Range(0f, 200f)]
    public float Force = 30f;

    [SerializeField]
    protected BallReseter ballReseter = default;

    [SerializeField]
    protected Collider col = default;

    [SerializeField]
    private SoundPlayer soundPlayer = default;

    public bool IsLanuched = false;

    protected Rigidbody ballRigidbody;
    protected Transform ballTransform;
    private Vector3 prevVelocity;

    protected void Awake()
    {
        col = GetComponent<SphereCollider>();
        ballReseter = GetComponent<BallReseter>();
        ballTransform = GetComponent<Transform>();
        ballRigidbody = GetComponent<Rigidbody>();
        soundPlayer = GetComponent<SoundPlayer>();
    }

    private void FixedUpdate()
    {
        prevVelocity = ballRigidbody.velocity;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        ChangeVelocity(collision);
        PreformRotation();
    }

    protected void PreformRotation()
    {
        ballTransform.rotation = Quaternion.FromToRotation(transform.up, ballRigidbody.velocity);
    }

    protected void ChangeVelocity(Collision collision)
    {
        ballRigidbody.velocity = Vector3.Reflect(prevVelocity, collision.contacts[0].normal);
        var paddleController = collision.collider.GetComponentInParent<PaddleController>();
        var brick = collision.collider.GetComponent<Brick>();

        if(!brick)
            soundPlayer.Play();

        if (paddleController)
            ballRigidbody.velocity += new Vector3(paddleController.GetMovementValue() * 10f, 0f, 0f);
        else if (brick)
            ballRigidbody.velocity *= brick.Data.Bounciness;
    }

    public void Launch(float horizontalSpeed)
    {
        ballRigidbody.velocity = new Vector3(horizontalSpeed * 10f, 5f, 0f) * Speed;
        col.enabled = true;
        IsLanuched = true;
    }


}
