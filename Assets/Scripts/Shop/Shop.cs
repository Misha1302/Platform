using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private AudioSource noMoneySound;
    [SerializeField] private TMP_Text moneyTMPText;
    [SerializeField] private GameObject[] locks;
    [SerializeField] private Button[] items;
    [SerializeField] private Button yesButton;
    [SerializeField] private BuyMsg msg;
    [SerializeField] private ShowTexture[] showTextures;

    private void Awake()
    {
        locks[0].SetActive(false);
        for (var i = 1; i < locks.Length; i++) locks[i].SetActive(PlayerPrefs.GetInt($"Item{i}") == 0);

        SetYesButton();
        SetItems();
    }

    private void SetYesButton()
    {
        yesButton.onClick.AddListener(msg.Yes);
    }

    private void SetItems()
    {
        var index = 0;
        foreach (var item in items)
        {
            item.GetComponentInChildren<TMP_Text>().text = SettingsData.Costs[index].ToString();

            var index1 = index;
            item.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetInt("Item" + index1) == 1)
                {
                    //SkinChanger.textureIndex = index1;
                    foreach (var showTexture in showTextures) showTexture.SetTexture(index1);
                }
                else
                {
                    msg.ShowMsgBox();
                    msg.SetIndex(index1);
                }
            });
            index++;
        }
    }

    public void SetTextureIndex(int index, int cost)
    {
        var isBought = PlayerPrefs.GetInt($"Item{index}") == 1;
        var money = Money.Coins;

        if (!isBought)
        {
            if (money < cost)
            {
                noMoneySound.Play();
                return;
            }

            Money.ReduceMoney(cost);
            moneyTMPText.text = Money.Coins.ToString();
            PlayerPrefs.SetInt($"Item{index}", 1);
            locks[index].SetActive(false);
        }

        //SkinChanger.textureIndex = index;
        SettingsData.setTextureIndex = index;
    }
}