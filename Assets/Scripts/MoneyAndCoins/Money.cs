using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public TMP_Text moneyText;
    public static int Coins { get; private set; }

    private void Awake()
    {
        SettingsData.Coins = PlayerPrefs.GetInt("Coins");
        Coins = SettingsData.Coins;
        moneyText.text = SettingsData.Coins.ToString();
    }

    public static void SaveMoney()
    {
        PlayerPrefs.SetInt("Coins", SettingsData.Coins);
        Coins = SettingsData.Coins;
    }

    public static void AddMoney(int addMoney)
    {
        SettingsData.Coins += addMoney;
        SaveMoney();
    }

    public static void ReduceMoney(int reduceMoney)
    {
        SettingsData.Coins -= reduceMoney;
        SaveMoney();
    }
}