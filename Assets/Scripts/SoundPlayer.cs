using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> clips = default;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play()
    {
        source.Stop();
        source.time = 0f;
        AudioClip clip = clips[Random.Range(0, clips.Count - 1)];
        source.clip = clip;
        source.pitch = Random.Range(1f, 1.5f);
        source.Play();
    }
}
