using UnityEngine;

[RequireComponent(typeof(Platform), typeof(Renderer))]
public class SkinChanger : MonoBehaviour
{
    private Platform _platform;
    private Renderer _renderer;

    private void Awake()
    {
        _platform = GetComponent<Platform>();
        _platform.SkinApply += SkinApplied;

        _renderer = GetComponent<Renderer>();
    }

    private void SkinApplied(Texture texture)
    {
        _renderer.material.mainTexture = texture;
    }
}