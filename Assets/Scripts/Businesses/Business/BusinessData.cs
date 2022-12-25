using UnityEngine;

namespace BusinessSimulator
{
    [CreateAssetMenu(fileName = nameof(BusinessData), menuName = "Business Data", order = 51)]
    public class BusinessData : ScriptableObject
    {
        private const int ImprovementsCount = 2;

        [SerializeField] private string _title;

        [SerializeField] private float _delay;
        [SerializeField] private float _cost;
        [SerializeField] private float _income;

        [SerializeField] private ImprovementData[] _improvementsData = new ImprovementData[ImprovementsCount];
        [SerializeField] private BlockData _blockData;

        public string Title => _title;

        public float Delay => _delay;
        public float Cost => _cost;
        public float Income => _income;

        public ImprovementData[] ImprovementsData => _improvementsData;
        public BlockData BlockData => _blockData;

        private void OnValidate()
        {
            if (_improvementsData.Length != ImprovementsCount)
            {
                Debug.LogError($"Only {ImprovementsCount} improvements available");
                _improvementsData = new ImprovementData[ImprovementsCount];
            }

            if (_blockData != null && (_blockData.ViewPrefab == null || _blockData.ViewPrefab.GetType() != typeof(BusinessView)))
            {
                Debug.LogError($"Need business block. Its View does not match the BusinessView");
                _blockData = null;
            }
        }
    }
}
