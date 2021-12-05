using UnityEngine;

using Object = UnityEngine.Object;

namespace RewardSlotsDemo
{

    public class CurrencyController
    {

        #region Fields

        private string _key;

        private CurrencyView _view;
        
        #endregion

        #region Properties

        public int Amount
        {

            get => CurrencyData.GetCurrencyAmount(_key);
            set
            {

                CurrencyData.SetCurrencyAmount(_key, value);

                _view.CurrentCount.text = value.ToString();

            }
            
        }

        #endregion

        #region Constructors

        public CurrencyController(RectTransform root, CurrencyView prefab, ERewardType rewardType, Sprite sprite)
        {

            _key    = CurrencyData.GetKeyByRewardType(rewardType);

            _view   = Object.Instantiate(prefab, root);

            _view.Image.sprite = sprite;

            Amount = Amount;

        }

        #endregion

    }

}