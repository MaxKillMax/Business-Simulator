using UnityEngine;
using UnityEngine.Events;

namespace BusinessSimulator
{
    public class BusinessGenerator : MonoBehaviour, IGenerator<Business>
    {
        [SerializeField] private BlockHandler _blockHandler;

        private BusinessData _data;
        private UnityAction _onLevelClicked;
        private UnityAction<int> _onImprovementClicked;

        public Business Result { get; private set; }
        public BusinessView View { get; private set; }

        public void Initialize(BusinessData data, UnityAction OnLevelUpClicked, UnityAction<int> OnImprovementClicked)
        {
            _data = data;
            _onLevelClicked = OnLevelUpClicked;
            _onImprovementClicked = OnImprovementClicked;
        }

        public void Generate()
        {
            Result = new(_data);
            GenerateView();
        }

        public void GenerateView()
        {
            _blockHandler.CreateBlock(_data.BlockData, out Block block);
            View = block.View as BusinessView;

            View.OnLevelUpClicked.AddListener(_onLevelClicked);
            View.OnImprovementClicked.AddListener(_onImprovementClicked);
        }
    }
}
