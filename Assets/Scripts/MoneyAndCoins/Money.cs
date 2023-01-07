using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace MoneyAndCoins
{
    public class Money : MonoBehaviour
    {
        [FormerlySerializedAs("moneyText")] public TMP_Text MoneyText;
        public static int Coins { get; private set; }

        private void Awake()
        {
            //PlayerPrefs.SetInt("Coins", 10000);
            SettingsData.Coins = PlayerPrefs.GetInt("Coins");
            Coins = SettingsData.Coins;
            MoneyText.text = SettingsData.Coins.ToString();
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
}