using UnityEngine;

namespace BusinessSimulator
{
    [CreateAssetMenu(fileName = nameof(ImprovementData), menuName = "Improvement Data", order = 51)]
    public class ImprovementData : ScriptableObject
    {
        [SerializeField] private string _title;
        [SerializeField] private float _cost;
        [SerializeField] private float _incomeMultiply;

        public string Title => _title;
        public float Cost => _cost;
        public float IncomeMultiply => _incomeMultiply;
    }
}
