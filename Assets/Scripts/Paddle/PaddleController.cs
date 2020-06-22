using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paddle
{
    public class PaddleController : MonoBehaviour
    {
        [SerializeField]
        [Range(0, 100)]
        public float horizontalSpeed = 10f;

        [SerializeField]
        private CameraBounds cameraBounds = default;

        [SerializeField]
        private Collider col = default;

        private BallController ball;
        private float horizontalMovement;

        private void Awake()
        {
            transform.position = new Vector3(0f, -7.05f, 15f);
        }

        private void OnEnable()
        {
            InputController.ReleaseBall += Launch;
        }

        private void OnDisable()
        {
            InputController.ReleaseBall -= Launch;
        }

        private void Update()
        {
            horizontalMovement = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
            PreformMovement(horizontalMovement);
        }

        private void PreformMovement(float horizontalMovement)
        {
            if (horizontalMovement != 0f)
            {
                Vector3 newPosition = transform.position + new Vector3(horizontalMovement, 0f, 0f);
                newPosition.x = Mathf.Clamp(newPosition.x, -cameraBounds.GetCameraWidth(), cameraBounds.GetCameraWidth());
                transform.position = newPosition;
            }
        }

        public float GetMovementValue()
        {
            return horizontalMovement;
        }

        public void ResetPosition()
        {
            transform.position = new Vector3(0f, -7.05f, 15f);
        }

        private void Launch()
        {
            ball.transform.SetParent(null);
            ball.Launch(GetMovementValue());
            col.enabled = true;
            ball = null;
        }

        public void SetBall(BallController ball)
        {
            this.ball = ball;
        }

        public void ParentBall(Transform ballParent, Vector3 position)
        {
            ball.transform.SetParent(ballParent);
            ball.transform.localPosition = position;
            ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            ball.IsLanuched = false;
        }

    }
}
