using System;
using Newtonsoft.Json;
using UnityEngine.Events;

namespace BusinessSimulator
{
    [Serializable]
    public class Improvement
    {
        public UnityEvent<Improvement> OnBought { get; private set; } = new();

        public string Title { get; private set; }
        public float Cost { get; private set; }
        public float IncomeMultiply { get; private set; }

        public bool IsBought { get; private set; }

        [JsonConstructor]
        public Improvement(UnityEvent<Improvement> onBought, string title, float cost, float incomeMultiply, bool isBought)
        {
            OnBought = onBought;
            Title = title;
            Cost = cost;
            IncomeMultiply = incomeMultiply;
            IsBought = isBought;
        }

        public Improvement(ImprovementData data)
        {
            Title = data.Title;
            Cost = data.Cost;
            IncomeMultiply = data.IncomeMultiply;
        }

        public void Buy()
        {
            IsBought = true;
            OnBought?.Invoke(this);
        }
    }
}
