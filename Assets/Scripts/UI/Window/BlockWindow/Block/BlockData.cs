using UnityEngine;

namespace BusinessSimulator
{
    [CreateAssetMenu(fileName = "BlockData", menuName = "Block Data", order = 51)]
    public class BlockData : ScriptableObject
    {
        [SerializeField] private View _prefab;

        public View ViewPrefab => _prefab;
    }
}
