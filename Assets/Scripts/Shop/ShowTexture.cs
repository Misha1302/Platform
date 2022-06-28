using UnityEngine;
using UnityEngine.UI;

public class ShowTexture : MonoBehaviour
{
    [SerializeField] private Texture[] textures;

    private RawImage _image;

    private void Start()
    {
        _image = GetComponent<RawImage>();
        //SetTexture(SkinChanger.textureIndex);
    }

    public void SetTexture(int index)
    {
        if (PlayerPrefs.GetInt("Item" + index) == 1) _image.texture = textures[index];
    }
}