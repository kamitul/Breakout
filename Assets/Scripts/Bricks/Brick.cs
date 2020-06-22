using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Brick : MonoBehaviour
{
    public BrickData Data;
    protected ItemDropController itemDrop;
    protected PointController pointController;
    protected ParticleSpawner particleSpawner;

    [SerializeField]
    protected List<ParticleSystem> particles = default;

    private MeshRenderer meshRenderer;
    private Collider col;
    [SerializeField]
    private SoundPlayer soundPlayer = default;

    private void Awake()
    {
        particleSpawner = new ParticleSpawner(particles);
        itemDrop = FindObjectOfType<ItemDropController>();
        pointController = FindObjectOfType<PointController>();

        meshRenderer = GetComponent<MeshRenderer>();
        col = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        soundPlayer.Play();
        var ball = collision.collider.GetComponent<BallController>();
        var projectile = collision.collider.GetComponent<Projectile>();
        if (ball)
        {
            TakeDamage(ball.Force);
        }
        else if(projectile)
        {
            TakeDamage(projectile.Damage);
        }
    }

    public void TakeDamage(float force)
    {
        StartCoroutine(GiveDamage(force));
    }

    private IEnumerator GiveDamage(float force)
    {
        DealDamage(force);
        if (Data.HP <= 0f)
        {
            meshRenderer.enabled = false;
            col.enabled = false;
        }
        VisualizeDamage();
        particleSpawner.Launch();
        yield return new WaitForSeconds(0.25f);
        DeactivateBrick();
    }

    private void DealDamage(float force)
    {
        Data.HP -= force;
    }

    public abstract void VisualizeDamage();
    public abstract void DeactivateBrick();
}
