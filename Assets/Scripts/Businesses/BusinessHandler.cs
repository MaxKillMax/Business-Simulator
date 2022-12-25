using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BusinessSimulator
{
    public class BusinessHandler : MonoBehaviour, ISaveable<List<Business>>
    {
        [SerializeField] private BusinessesData _data;
        [SerializeField] private BusinessGenerator _businessGenerator;
        [SerializeField] private Wallet _wallet;

        private readonly Dictionary<Business, BusinessView> _views = new();
        private readonly List<Business> _businesses = new();

        private void Start()
        {
            if (_businesses.Count == 0)
            {
                InitializeBusiness(GetNextBusinessData());
                ImproveBusiness(_businesses[^1]);
            }
        }

        private void Update()
        {
            Business business;

            for (int i = 0; i < _businesses.Count; i++)
            {
                business = _businesses[i];

                if (!business.IsBought)
                    return;

                if (business.Time >= business.Delay)
                {
                    _wallet.AddBalance(business.Income);
                    business.Time = 0;
                }

                business.Time += Time.deltaTime;

                _views[business].SetProgress(business.Progress);
            }
        }

        private void TryImproveBusiness(Business business)
        {
            if (!_wallet.TrySpendBalance(business.Cost))
                return;

            ImproveBusiness(business);
        }

        private void ImproveBusiness(Business business)
        {
            if (!business.IsBought && GetNextBusinessData() != default)
                InitializeBusiness(GetNextBusinessData());

            business.Improve();
            UpdateView(business);
        }

        private void TryBuyImprovement(Business business, int index)
        {
            if (business.Improvements[index].IsBought || !_wallet.TrySpendBalance(business.Improvements[index].Cost))
                return;

            BuyImprovement(business, index);
        }

        private void BuyImprovement(Business business, int index)
        {
            business.Improvements[index].Buy();
            _views[business].SetImprovementBuyState(index, true);
            UpdateView(business);
        }

        private void InitializeBusiness(BusinessData data, Business currentBusiness = default)
        {
            Business business = currentBusiness != default ? currentBusiness : default;

            _businessGenerator.Initialize(data, () => TryImproveBusiness(business), (i) => TryBuyImprovement(business, i));
            _businessGenerator.Generate();

            if (business == default)
                business = _businessGenerator.Result;
            BusinessView view = _businessGenerator.View;

            _businesses.Add(business);
            _views.Add(business, view);

            UpdateView(business);
        }

        private void UpdateView(Business business)
        {
            BusinessViewData viewData = GenerateBusinessViewData(business);
            _views[business].Initialize(viewData);
            Debug.Log("View updated");
        }

        private BusinessData GetNextBusinessData()
        {
            BusinessData[] datas = _data.Datas.ToArray();
            return datas.Length > _businesses.Count ? datas[_businesses.Count] : default;
        }

        private BusinessViewData GenerateBusinessViewData(Business business)
        {
            return new()
            {
                Title = business.Title,
                Level = business.Level,
                Income = business.Income,
                LevelUpCost = business.Cost,

                ImprovementButtonData0 = new BussinessImprovementButtonData()
                {
                    Title = business.Improvements[0].Title,
                    Cost = business.Improvements[0].Cost,
                    IncomeMultiply = business.Improvements[0].IncomeMultiply
                },

                ImprovementButtonData1 = new BussinessImprovementButtonData()
                {
                    Title = business.Improvements[1].Title,
                    Cost = business.Improvements[1].Cost,
                    IncomeMultiply = business.Improvements[1].IncomeMultiply
                }
            };
        }

        public List<Business> GetSaveData() => _businesses;

        public void LoadData(List<Business> saveData)
        {
            BusinessData[] datas = _data.Datas.ToArray();

            for (int i = 0; i < saveData.Count; i++)
            {
                InitializeBusiness(datas[i], saveData[i]);

                BusinessView view = _views[_businesses[i]];
                _views.Remove(_businesses[i]);
                _businesses[i] = saveData[i];
                _views.Add(_businesses[i], view);

                for (int x = 0; x < datas[i].ImprovementsData.Length; x++)
                    _views[_businesses[i]].SetImprovementBuyState(x, _businesses[i].Improvements[x].IsBought);

                UpdateView(_businesses[i]);
            }
        }
    }
}
