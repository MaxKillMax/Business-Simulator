using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BusinessSimulator
{
    public class ImprovementButton : MonoBehaviour
    {
        public UnityEvent OnClicked { get; private set; } = new();

        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _costText;
        [SerializeField] private TMP_Text _incomeText;
        [SerializeField] private Button _button;

        [Space]

        [SerializeField] private GameObject _boughtPanel;
        [SerializeField] private GameObject _unboughtPanel;

        private void Awake()
        {
            _button.onClick.AddListener(() => OnClicked?.Invoke());
        }

        public void SetBuyState(bool state)
        {
            _boughtPanel.SetActive(state);
            _unboughtPanel.SetActive(!state);
        }

        public void Initialize(BussinessImprovementButtonData data)
        {
            _titleText.text = $"\"{data.Title}\"";
            _costText.text = $"{data.Cost}$";
            _incomeText.text = $"+ {data.IncomeMultiply}%";
        }
    }
}
