using UnityEngine;
using System.Collections;

public class RepeatingBackground : MonoBehaviour
{
    public float Speed;
    public MeshRenderer meshRenderer;

    private void Update()
    {
        float offset = Time.time * Speed;
        meshRenderer.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}