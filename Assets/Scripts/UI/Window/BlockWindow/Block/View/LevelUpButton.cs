using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BusinessSimulator
{
    public class LevelUpButton : MonoBehaviour
    {
        public UnityEvent OnClicked { get; private set; } = new();

        [SerializeField] private TMP_Text _costText;
        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(() => OnClicked?.Invoke());
        }

        public void Initialize(float cost)
        {
            _costText.text = $"{cost}$";
        }
    }
}
