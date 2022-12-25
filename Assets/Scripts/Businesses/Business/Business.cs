using System;
using Newtonsoft.Json;
using UnityEngine.Events;

namespace BusinessSimulator
{
    [Serializable]
    public class Business
    {
        public UnityEvent<Business> OnImproved { get; private set; } = new();

        [JsonProperty("_baseCost")] private readonly float _baseCost;
        [JsonProperty("_baseIncome")] private readonly float _baseIncome;

        public string Title { get; private set; }
        public Improvement[] Improvements { get; private set; }

        public int Level { get; private set; }

        public float Cost => (Level + 1) * _baseCost;
        public float Income => Level * _baseIncome * GetTotalImprovementMultiply();

        public bool IsBought => Level > 0;

        public float Delay { get; private set; }
        public float Time { get; set; }
        public float Progress => Time / Delay;

        [JsonConstructor]
        public Business(UnityEvent<Business> onImproved, float baseCost, float baseIncome, string title, Improvement[] improvements, int level, float delay, float time)
        {
            OnImproved = onImproved;
            _baseCost = baseCost;
            _baseIncome = baseIncome;
            Title = title;
            Improvements = improvements;
            Level = level;
            Delay = delay;
            Time = time;
        }

        public Business(BusinessData data)
        {
            Title = data.Title;

            Improvements = new Improvement[data.ImprovementsData.Length];
            for (int i = 0; i < data.ImprovementsData.Length; i++)
                Improvements[i] = new Improvement(data.ImprovementsData[i]);

            Delay = data.Delay;
            _baseCost = data.Cost;
            _baseIncome = data.Income;

            Level = 0;
        }

        public void Improve()
        {
            Level++;
            OnImproved?.Invoke(this);
        }

        private float GetTotalImprovementMultiply()
        {
            float multiply = 1;

            for (int i = 0; i < Improvements.Length; i++)
            {
                if (Improvements[i].IsBought)
                    multiply *= Improvements[i].IncomeMultiply;
            }

            return multiply;
        }
    }
}
