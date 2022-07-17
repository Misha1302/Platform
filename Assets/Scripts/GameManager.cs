using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Texture[] textures;

    [SerializeField] private Settings settings;
    [SerializeField] private Platform platform;
    [SerializeField] private PlatformScaler scaler;

    private void Start()
    {
        scaler.Setup(settings.PlatformSizeScalePares, settings.PlatformDepth);
        platform.Setup(settings.PlatformSizeScalePares[^(SettingsData.Mode + 1)].Size);
        platform.ApplySkin(textures[SettingsData.SetTextureIndex]);
    }
}