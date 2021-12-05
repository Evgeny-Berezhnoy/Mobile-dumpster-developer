using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AIDemo
{

    public class MainWindowObserver : MonoBehaviour
    {

        #region Constants

        private const int _crimeThreshold = 2;

        #endregion

        #region Fields

        [SerializeField] private TMP_Text _countHealthText;
        [SerializeField] private TMP_Text _countPowerText;
        [SerializeField] private TMP_Text _countMoneyText;
        [SerializeField] private TMP_Text _crimeLevelText;

        [SerializeField] private TMP_Text _countPowerEnemyText;

        [SerializeField] private Button _addHealthButton;
        [SerializeField] private Button _minusHealthButton;
        
        [SerializeField] private Button _addPowerButton;
        [SerializeField] private Button _minusPowerButton;

        [SerializeField] private Button _addCoinsButton;
        [SerializeField] private Button _minusCoinsButton;

        [SerializeField] private Button _increaseCrimeLevelButton;
        [SerializeField] private Button _decreaseCrimeLevelButton;

        [SerializeField] private Button _fightButton;
        [SerializeField] private Button _passButton;

        private int _allCountMoneyPlayer;
        private int _allCountHealthPlayer;
        private int _allCountPowerPlayer;
        private int _crimeLevel;

        private Money _money;
        private Health _heath;
        private Power _power;

        private Enemy _enemy;

        #endregion

        #region Properties

        private int CrimeLevel
        {

            get => _crimeLevel;
            set
            {

                if (value < 0) return;
            
                _crimeLevel = value;

                _passButton.gameObject.SetActive(_crimeLevel < _crimeThreshold);

                _crimeLevelText.text = _crimeLevel.ToString();

            }

        }

        #endregion

        #region Unity events

        private void Start()
        {

            _enemy = new Enemy("Enemy Flappy");

            _money = new Money(nameof(Money));
            _money.Attach(_enemy);

            _heath = new Health(nameof(Health));
            _heath.Attach(_enemy);

            _power = new Power(nameof(Power));
            _power.Attach(_enemy);

            _addCoinsButton.onClick.AddListener(() => ChangeMoney(true));
            _minusCoinsButton.onClick.AddListener(() => ChangeMoney(false));

            _addHealthButton.onClick.AddListener(() => ChangeHealth(true));
            _minusHealthButton.onClick.AddListener(() => ChangeHealth(false));

            _addPowerButton.onClick.AddListener(() => ChangePower(true));
            _minusPowerButton.onClick.AddListener(() => ChangePower(false));

            _increaseCrimeLevelButton.onClick.AddListener(() => ChangeCrimeLevel(true)) ;
            _decreaseCrimeLevelButton.onClick.AddListener(() => ChangeCrimeLevel(false));
            
            _fightButton.onClick.AddListener(Fight);
            _passButton.onClick.AddListener(Pass);

            SetEnemyPowerText();

        }

        private void OnDestroy()
        {

            _addHealthButton.onClick.RemoveAllListeners();
            _minusHealthButton.onClick.RemoveAllListeners();

            _addPowerButton.onClick.RemoveAllListeners();
            _minusPowerButton.onClick.RemoveAllListeners();

            _addCoinsButton.onClick.RemoveAllListeners();
            _minusCoinsButton.onClick.RemoveAllListeners();

            _money.Detach(_enemy);
            _heath.Detach(_enemy);
            _power.Detach(_enemy);
            
            _fightButton.onClick.RemoveAllListeners();
            _passButton.onClick.RemoveAllListeners();

        }

        #endregion

        #region Methods

        private void ChangeHealth(bool isAddCount)
        {

            if (isAddCount)
                _allCountHealthPlayer++;
            else
                _allCountHealthPlayer--;

            ChangeDataWindow(_allCountHealthPlayer, DataType.Health);

        }

        private void ChangePower(bool isAddCount)
        {

            if (isAddCount)
                _allCountPowerPlayer++;
            else
                _allCountPowerPlayer--;

            ChangeDataWindow(_allCountPowerPlayer, DataType.Power);

        }

        private void ChangeMoney(bool isAddCount)
        {

            if (isAddCount)
                _allCountMoneyPlayer++;
            else
                _allCountMoneyPlayer--;

            ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);

        }

        private void ChangeCrimeLevel(bool isAddCount)
        {

            if (isAddCount)
                CrimeLevel++;
            else
                CrimeLevel--;

        }

        private void Fight()
        {

            Debug.Log(_allCountPowerPlayer >= _enemy.Power
               ? "<color=#07FF00>Win!!!</color>"
               : "<color=#FF0000>Lose!!!</color>");

        }

        private void Pass()
        {

            Debug.Log("You have escaped from the enemy.");

        }

        private void ChangeDataWindow(int countChangeData, DataType dataType)
        {

            switch (dataType)
            {

                case DataType.Money:
                    _countMoneyText.text = countChangeData.ToString();
                    _money.Money = countChangeData;
                    break;

                case DataType.Health:
                    _countHealthText.text = countChangeData.ToString();
                    _heath.Health = countChangeData;
                    break;

                case DataType.Power:
                    _countPowerText.text = countChangeData.ToString();
                    _power.Power = countChangeData;
                    break;
                
            }

            SetEnemyPowerText();

        }

        private void SetEnemyPowerText()
        {

            _countPowerEnemyText.text = _enemy.Power.ToString();
            
        }

        #endregion

    }

}