using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Settings : ScriptableObject
{
    [SerializeField] private float _platformDepth = 0.3f;

    [SerializeField]
    private List<PlatformSizeScalePare> _platformSizes = new()
    {
        new PlatformSizeScalePare(PlatformSize.Small, 1.0f),
        new PlatformSizeScalePare(PlatformSize.Medium, 1.5f),
        new PlatformSizeScalePare(PlatformSize.Big, 2.0f),
    };

    public IReadOnlyList<PlatformSizeScalePare> PlatformSizeScalePares => _platformSizes;

    public float PlatformDepth => _platformDepth;
}
