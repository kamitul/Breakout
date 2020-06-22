using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage = 30f;
    [SerializeField]
    private Rigidbody rg = default;

    private void OnCollisionEnter(Collision collision)
    {
        var brick = collision.collider.GetComponent<Brick>();
        if(brick)
        {
            Destroy(this.gameObject);
        }
        var bound = collision.collider.GetComponent<Bound>();
        if(bound)
        {
            Destroy(this.gameObject);
        }
    }

    public void Launch(float force)
    {
        rg.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}
