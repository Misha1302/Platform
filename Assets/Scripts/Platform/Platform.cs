using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public event Action<PlatformSize> PlatformResize;
    public event Action<Texture> SkinApply;

    public PlatformSize Size { get; private set; }
    public Texture Texture { get; private set; }

    public void Setup(PlatformSize size)
    {
        Size = size;
        PlatformResize?.Invoke(size);
    }

    public void ApplySkin(Texture texture)
    {
        Texture = texture;
        SkinApply?.Invoke(texture);
    }
}
