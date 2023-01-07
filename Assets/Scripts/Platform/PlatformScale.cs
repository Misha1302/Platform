using UnityEngine;

namespace Platform
{
    public class PlatformScale : MonoBehaviour
    {
        [SerializeField] private float scale = 1;

        private void Start()
        {
            var mode = SettingsData.Mode;
            scale = mode == 0 ? 1.2f : 1;

            var thisTransform = transform;
            var localScale = thisTransform.localScale;
            localScale = new Vector3(localScale.x * scale, 0.5f, localScale.z * scale);
            thisTransform.localScale = localScale;
        }
    }
}