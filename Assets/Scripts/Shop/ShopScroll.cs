using UnityEngine;

public class ShopScroll : MonoBehaviour
{
    [SerializeField] private float thrust;
    [SerializeField] private RectTransform shop;
    [SerializeField] private int maxX;
    [SerializeField] private int minX;

    private Scroll _scroll;

    private void Start()
    {
        _scroll = FindObjectOfType<Scroll>();
    }

    private void FixedUpdate()
    {
        // despite the fact that the game is in 2d, the parameter "translation" is not explicitly cast to "Vector3"
        shop.Translate(new Vector3(_scroll.ScrollValue.x * thrust, 0, 0));
        var shopPos = shop.localPosition;
        if (shopPos.x > maxX) shopPos.x = maxX;
        else if (shopPos.x < minX) shopPos.x = minX;
        shop.localPosition = shopPos;
    }
}