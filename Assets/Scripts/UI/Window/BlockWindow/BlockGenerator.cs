using UnityEngine;

namespace BusinessSimulator
{
    public class BlockGenerator : MonoBehaviour, IGenerator<Block>
    {
        [SerializeField] private Block _prefab;
        [SerializeField] private Transform _parent;
        private BlockData _data;

        public Block Result { get; private set; }

        public void Initialize(BlockData data)
        {
            _data = data;
        }

        public void Generate()
        {
            Result = Instantiate(_prefab, _parent);
            View view = Instantiate(_data.ViewPrefab, Result.transform);
            Result.SetView(view);
        }
    }
}
