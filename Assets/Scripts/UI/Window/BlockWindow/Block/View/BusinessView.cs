using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BusinessSimulator
{
    public class BusinessView : View
    {
        public UnityEvent<int> OnImprovementClicked { get; private set; } = new();
        public UnityEvent OnLevelUpClicked { get; private set; } = new();

        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _incomeText;

        [SerializeField] private Image _progressFillerImage;

        [SerializeField] private LevelUpButton _levelUpButton;
        [SerializeField] private ImprovementButton _improvementButton0;
        [SerializeField] private ImprovementButton _improvementButton1;

        private void Awake()
        {
            _levelUpButton.OnClicked.AddListener(() => OnLevelUpClicked?.Invoke());
            _improvementButton0.OnClicked.AddListener(() => OnImprovementClicked?.Invoke(0));
            _improvementButton1.OnClicked.AddListener(() => OnImprovementClicked?.Invoke(1));

            enabled = false;
        }

        public void Initialize(BusinessViewData data)
        {
            _titleText.text = $"\"{data.Title}\"";
            _levelText.text = data.Level.ToString();
            _incomeText.text = $"{data.Income}$";

            _levelUpButton.Initialize(data.LevelUpCost);

            _improvementButton0.Initialize(data.ImprovementButtonData0);
            _improvementButton1.Initialize(data.ImprovementButtonData1);

            enabled = true;
        }

        /// <summary>
        /// 0 to 1
        /// </summary>
        /// <param name="progress"></param>
        public void SetProgress(float progress)
        {
            _progressFillerImage.fillAmount = progress;
        }

        public void SetImprovementBuyState(int index, bool state)
        {
            ImprovementButton button = index == 0 ? _improvementButton0 : _improvementButton1;
            button.SetBuyState(state);
        }
    }
}
