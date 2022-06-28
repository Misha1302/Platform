using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Platform))]
public class PlatformScaler : MonoBehaviour
{
    private const float DEPTH_DEFAULT = 0.3f;

    private Platform _platform;
    private IReadOnlyList<PlatformSizeScalePare> _sizes = new List<PlatformSizeScalePare>();
    private float _platformDepth;

    private void Awake()
    {
        _platform = GetComponent<Platform>();
        _platform.PlatformResize += OnPlatformResized;
    }

    public void Setup(IReadOnlyList<PlatformSizeScalePare> sizes, float platformDepth = DEPTH_DEFAULT)
    {
        _sizes = sizes;
        _platformDepth = platformDepth;
    }

    private void OnPlatformResized(PlatformSize size)
    {
        float scale = 1;

        var sizeQueryResult = _sizes.Where(x => x.Size == size);

        if (sizeQueryResult.Any())
            scale = sizeQueryResult.First().Scale;

        transform.localScale = new(scale, _platformDepth, scale);
    }
}
