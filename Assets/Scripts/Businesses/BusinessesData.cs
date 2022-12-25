using System.Collections.Generic;
using UnityEngine;

namespace BusinessSimulator
{
    [CreateAssetMenu(fileName = nameof(BusinessesData), menuName = "Businesses Data", order = 51)]
    public class BusinessesData : ScriptableObject
    {
        [SerializeField] private BusinessData[] _datas;

        public IEnumerable<BusinessData> Datas => _datas;
    }
}
