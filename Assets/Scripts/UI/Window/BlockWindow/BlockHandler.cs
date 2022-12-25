using System.Collections.Generic;
using UnityEngine;

namespace BusinessSimulator
{
    public class BlockHandler : MonoBehaviour
    {
        [SerializeField] private BlockGenerator _generator;

        private readonly List<Block> _blocks = new();

        public void CreateBlock(BlockData data)
        {
            _generator.Initialize(data);
            _generator.Generate();

            _blocks.Add(_generator.Result);
        }

        public void CreateBlock(BlockData data, out Block block)
        {
            CreateBlock(data);
            block = _blocks[^1];
        }
    }
}
