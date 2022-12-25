using UnityEngine;

namespace BusinessSimulator
{
    public class WalletHandler : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private WalletDisplay _display;

        private void Awake()
        {
            _wallet.OnValueChanged.AddListener(UpdateDisplay);
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            _display.UpdateBalanceText(_wallet.Balance);
        }
    }
}
