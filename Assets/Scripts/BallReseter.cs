using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReseter : MonoBehaviour, IResetable
{
    [SerializeField]
    private Rigidbody rigidbody = default;
    [SerializeField]
    private Collider collider = default;

    public void ResetState()
    {
        transform.rotation = Quaternion.identity;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        collider.enabled = false;
    }
}
