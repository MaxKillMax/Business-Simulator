using System.Collections.Generic;
using UnityEngine;

namespace BusinessSimulator
{
    public class SerializatorHandler : MonoBehaviour
    {
        private string WalletSavePath => Application.persistentDataPath + "/WalletData.json";
        private string BusinessesSavePath => Application.persistentDataPath + "/BusinessesData.json";

        [SerializeField] private Wallet _wallet;
        [SerializeField] private BusinessHandler _businessHandler;

        private void Awake()
        {
            float balance = Serializator.Load<float>(WalletSavePath);
            if (balance != default)
                _wallet.LoadData(balance);

            List<Business> businesses = Serializator.Load<List<Business>>(BusinessesSavePath);
            if (businesses != default)
                _businessHandler.LoadData(businesses);
        }

        private void OnDestroy()
        {
            Serializator.Save(_wallet.GetSaveData(), WalletSavePath);
            Serializator.Save(_businessHandler.GetSaveData(), BusinessesSavePath);
        }
    }
}
