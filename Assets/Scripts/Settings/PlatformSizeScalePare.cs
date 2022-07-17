using System;
using UnityEngine;

[Serializable]
public struct PlatformSizeScalePare
{
    [SerializeField] private PlatformSize size;
    [SerializeField] private float scale;

    public PlatformSizeScalePare(PlatformSize size, float scale)
    {
        this.size = size;
        this.scale = scale;
    }

    public PlatformSize Size => size;
    public float Scale => scale;
}