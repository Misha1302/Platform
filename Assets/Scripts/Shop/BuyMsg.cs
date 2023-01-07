using UnityEngine;
using UnityEngine.Events;

namespace Shop
{
    public class BuyMsg : MonoBehaviour
    {
        [SerializeField] private GameObject msgBox;
        [SerializeField] private Shop shop;

        private int index;
    
        private void Awake()
        {
            shop ??= FindObjectOfType<Shop>();
        }

        public UnityAction SetIndex(int index)
        {
            this.index = index;
            return null;
        }

        public void ShowMsgBox()
        {
            msgBox.SetActive(true);
        }

        public void HideMsgBox()
        {
            msgBox.SetActive(false);
        }

        public void Yes()
        {
            OnYes(index);
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
}