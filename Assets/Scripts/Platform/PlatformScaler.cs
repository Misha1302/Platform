using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Platform))]
public class PlatformScaler : MonoBehaviour
{
    private Platform _platform;
    private float _platformDepth;
    private IReadOnlyList<PlatformSizeScalePare> _sizes = new List<PlatformSizeScalePare>();

    private void Awake()
    {
        _platform = GetComponent<Platform>();
        _platform.PlatformResize += OnPlatformResized;
    }

    public void Setup(IReadOnlyList<PlatformSizeScalePare> sizes, float platformDepth)
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

        transform.localScale = new Vector3(scale, _platformDepth, scale);
    }
}