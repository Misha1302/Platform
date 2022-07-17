using UnityEngine;

public class BuyMsg : MonoBehaviour
{
    [SerializeField] private GameObject msgBox;
    [SerializeField] private Shop shop;

    private int _index;

    private void Awake()
    {
        shop ??= FindObjectOfType<Shop>();
    }

    public void SetIndex(int index)
    {
        _index = index;
    }

    public void ShowMsgBox()
    {
        msgBox.SetActive(true);
    }

    private void HideMsgBox()
    {
        msgBox.SetActive(false);
    }

    public void Yes()
    {
        OnYes(_index);
    }

    public void No()
    {
        OnNo();
    }

    private void OnYes(int index)
    {
        var cost = SettingsData.Costs[index];
        shop.SetTextureIndex(index, cost);
        HideMsgBox();
    }

    private void OnNo()
    {
        HideMsgBox();
    }
}