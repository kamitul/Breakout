using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    [SerializeField]
    protected MeshRenderer meshRenderer;

    protected void Update()
    {
        SetColor();
    }

    public void SetColor()
    {
        meshRenderer.material.color = new Color(Mathf.Clamp(Mathf.Sin(Time.time), 0.35f, 1f), Mathf.Clamp(Mathf.Cos(Time.time), 0.35f, 1f), Mathf.Clamp(Mathf.Sin(Time.time * 2), 0.35f, 1f));
    }
}
