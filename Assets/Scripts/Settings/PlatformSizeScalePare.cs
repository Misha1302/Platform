using System;
using UnityEngine;

[Serializable]
public struct PlatformSizeScalePare
{
    [SerializeField] private PlatformSize _size;
    [SerializeField] private float _scale;

    public PlatformSizeScalePare(PlatformSize size, float scale)
    {
        _size = size;
        _scale = scale;
    }

    public PlatformSize Size => _size;
    public float Scale => _scale;
}
