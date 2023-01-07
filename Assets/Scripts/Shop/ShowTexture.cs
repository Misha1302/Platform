using Platform;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ShowTexture : MonoBehaviour
    {
        [SerializeField] private Texture[] textures;

        private RawImage image;

        private void Start()
        {
            image = GetComponent<RawImage>();
            SetTexture(PlatformTexture.TextureIndex);
        }

        public void SetTexture(int index)
        {
            if (PlayerPrefs.GetInt("Item" + index) == 1) image.texture = textures[index];
        }
    }
}