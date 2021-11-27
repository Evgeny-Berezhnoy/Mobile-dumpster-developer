using TMPro;
using UnityEngine;

namespace RewardSlotsDemo
{

    public class CurrencyView : MonoBehaviour
    {

        #region Constants

        private const string WoodKey    = nameof(WoodKey);
        private const string GoldKey    = nameof(GoldKey);

        #endregion

        #region Static fields

        public static CurrencyView Instance;

        [SerializeField] private TMP_Text _currentCountWood;
        [SerializeField] private TMP_Text _currentCountGold;

        #endregion

        #region Properties

        private int Wood
        {
        
            get => PlayerPrefs.GetInt(WoodKey, 0);
            set => PlayerPrefs.SetInt(WoodKey, value);
        
        }

        private int Gold
        {

            get => PlayerPrefs.GetInt(GoldKey, 0);
            set => PlayerPrefs.SetInt(GoldKey, value);
        
        }

        #endregion

        #region Unity events

        private void Awake()
        {
        
            Instance = this;
        
        }

        private void Start()
        {

            RefreshText();
        
        }

        #endregion

        #region Methods

        public void AddWood(int value)
        {
        
            Wood += value;

            RefreshText();
        
        }

        public void AddGold(int value)
        {
        
            Gold += value;

            RefreshText();
        
        }

        private void RefreshText()
        {

            _currentCountWood.text = Wood.ToString();
            _currentCountGold.text = Gold.ToString();
        
        }

        #endregion

    }

}