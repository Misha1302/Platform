using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Settings : ScriptableObject
{
    [SerializeField] private float platformDepth = 0.5f;

    [SerializeField] private List<PlatformSizeScalePare> platformSizes = new()
    {
        new PlatformSizeScalePare(PlatformSize.Small, 1.0f),
        new PlatformSizeScalePare(PlatformSize.Medium, 1.5f),
        new PlatformSizeScalePare(PlatformSize.Big, 2.0f)
    };

    public IReadOnlyList<PlatformSizeScalePare> PlatformSizeScalePares => platformSizes;

    public float PlatformDepth => platformDepth;
}