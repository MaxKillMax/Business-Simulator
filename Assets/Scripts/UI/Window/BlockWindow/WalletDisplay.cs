using TMPro;
using UnityEngine;

namespace BusinessSimulator
{
    public class WalletDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _balanceText;

        public void UpdateBalanceText(float balance)
        {
            _balanceText.text = $"{balance}$";
        }
    }
}
