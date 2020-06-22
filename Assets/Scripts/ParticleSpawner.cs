using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner
{
    private List<ParticleSystem> particles;

    public ParticleSpawner(List<ParticleSystem> particles)
    {
        this.particles = particles;
    }

    public void Launch()
    {
        for (int i = 0; i < particles.Count; ++i)
        {
            particles[i].Stop();
            particles[i].Play();
        }
    }
}
