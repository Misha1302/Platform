using UnityEngine;

public class ManagerOfGame : MonoBehaviour
{
    [SerializeField] private Texture _texture;

    [SerializeField] private Settings _settings;
    [SerializeField] private Platform _platform;
    [SerializeField] private PlatformScaler _scaler;

    private void Start()
    {
        _scaler.Setup(_settings.PlatformSizeScalePares);
        _platform.Setup(PlatformSize.Medium);
        _platform.ApplySkin(_texture);
    }
}
