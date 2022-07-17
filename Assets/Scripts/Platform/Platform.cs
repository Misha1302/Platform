using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public event Action<PlatformSize> PlatformResize;
    public event Action<Texture> SkinApply;

    public void Setup(PlatformSize size)
    {
        PlatformResize?.Invoke(size);
    }

    public void ApplySkin(Texture texture)
    {
        SkinApply?.Invoke(texture);
    }
}