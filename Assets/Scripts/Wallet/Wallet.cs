using UnityEngine;
using UnityEngine.Events;

namespace BusinessSimulator
{
    public class Wallet : MonoBehaviour, ISaveable<float>
    {
        public UnityEvent OnValueChanged { get; private set; } = new();

        [SerializeField] private float _balance;

        public float Balance => _balance;

        public void AddBalance(float value)
        {
            _balance += value;
            OnValueChanged?.Invoke();
        }

        public bool TrySpendBalance(float value)
        {
            if (_balance < value)
                return false;

            AddBalance(-value);
            return true;
        }

        public float GetSaveData() => _balance;

        public void LoadData(float saveData) => _balance = saveData;
    }
}
