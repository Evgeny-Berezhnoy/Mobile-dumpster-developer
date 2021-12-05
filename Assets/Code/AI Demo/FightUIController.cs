using System;
using UnityEngine;
using Interfaces;
using Game;
using UserInterface;

using Object = UnityEngine.Object;

namespace AIDemo
{

    public class FightUIController : IGameStateToggleListener, IDisposableAdvanced
    {

        #region Constants

        private const string _winNotification = "<color=#07FF00>Win!!!</color>";
        private const string _lossNotification = "<color=#FF0000>Lose!!!</color>";
        private const string _passNotification = "You have escaped from the enemy.";
        
        #endregion

        #region Fields

        private int _allCountHealthPlayer;
        private int _allCountPowerPlayer;
        private int _allCountMoneyPlayer;
        private int _crimeLevel;

        private Money _money;
        private Health _heath;
        private Power _power;

        private Enemy _enemy;

        private FightUIView _view;

        #endregion

        #region Interfaces Properties

        public GameStateController CurrentGameStateController { get; private set; }

        public bool IsDisposed { get; private set; }

        #endregion

        #region Properties
        
        private int CrimeLevel
        {

            get => _crimeLevel;
            set
            {

                if (value < 0) return;
            
                _crimeLevel = value;

                _view.PassButton.gameObject.SetActive(_crimeLevel < _view.CrimeThreshold);

                _view.CrimeLevelText.text = _crimeLevel.ToString();

            }

        }

        #endregion

        #region Constructors

        public FightUIController(RectTransform root, FightUIView prefab, GameStateController gameStateController)
        {

            _enemy = new Enemy("Enemy Flappy");

            _money = new Money(nameof(Money));
            _money.Attach(_enemy);

            _heath = new Health(nameof(Health));
            _heath.Attach(_enemy);

            _power = new Power(nameof(Power));
            _power.Attach(_enemy);

            _view = Object.Instantiate(prefab, root);

            _view.AddPowerButton.AddHandler(() => ChangeCharachteristic(ref _allCountPowerPlayer, true, DataType.Power));
            _view.MinusPowerButton.AddHandler(() => ChangeCharachteristic(ref _allCountPowerPlayer, false, DataType.Power));

            _view.AddHealthButton.AddHandler(() => ChangeCharachteristic(ref _allCountHealthPlayer, true, DataType.Health));
            _view.MinusHealthButton.AddHandler(() => ChangeCharachteristic(ref _allCountHealthPlayer, false, DataType.Health));

            _view.AddCoinsButton.AddHandler(() => ChangeCharachteristic(ref _allCountMoneyPlayer, true, DataType.Money));
            _view.MinusCoinsButton.AddHandler(() => ChangeCharachteristic(ref _allCountMoneyPlayer, false, DataType.Money));

            _view.IncreaseCrimeLevelButton.AddHandler(() => ChangeCrimeLevel(true));
            _view.DecreaseCrimeLevelButton.AddHandler(() => ChangeCrimeLevel(false));

            _view.FightButton.AddHandler(Fight);
            _view.PassButton.AddHandler(Pass);

            SetEnemyPowerText();

            CurrentGameStateController = gameStateController;
            CurrentGameStateController.AddHandler(OnGameStateChange);

        }

        #endregion

        #region Destructors

        ~FightUIController()
        {

            Dispose();

        }

        #endregion

        #region Interfaces Methods

        public void OnGameStateChange(EGameState state)
        {

            switch (state)
            {

                case EGameState.Fight:

                    SwitchOn();

                    break;

                case EGameState.Quit:

                    Dispose();

                    break;

                default:

                    SwitchOff();

                    break;

            };

        }

        public void SwitchOff()
        {

            _view.gameObject.SetActive(false);

        }

        public void SwitchOn()
        {

            _view.gameObject.SetActive(true);

        }

        public void Dispose()
        {

            if (IsDisposed)
            {

                return;

            }

            IsDisposed = true;

            _money.Detach(_enemy);
            _heath.Detach(_enemy);
            _power.Detach(_enemy);
            
            _view.AddHealthButton.Dispose();
            _view.MinusHealthButton.Dispose();

            _view.AddPowerButton.Dispose();
            _view.MinusPowerButton.Dispose();

            _view.AddCoinsButton.Dispose();
            _view.MinusCoinsButton.Dispose();

            _view.FightButton.Dispose();
            _view.PassButton.Dispose();

            Object.Destroy(_view);

            CurrentGameStateController?.RemoveHandler(OnGameStateChange);
            
            GC.SuppressFinalize(this);

        }

        #endregion

        #region Methods

        private void ChangeCharachteristic(ref int charachteristic, bool isAddCount, DataType dataType)
        {

            if (isAddCount)
                charachteristic++;
            else
                charachteristic--;

            ChangeDataWindow(charachteristic, dataType);

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

            if(_allCountPowerPlayer < _enemy.Power)
            {

                Debug.Log(_lossNotification);

                return;

            };

            Debug.Log(_winNotification);

            CurrentGameStateController.State = EGameState.Play;

        }

        private void Pass()
        {

            Debug.Log(_passNotification);

            CurrentGameStateController.State = EGameState.Play;
            
        }

        private void ChangeDataWindow(int countChangeData, DataType dataType)
        {

            switch (dataType)
            {

                case DataType.Money:

                    _money.Money                = countChangeData;
                    _view.CountMoneyText.text   = countChangeData.ToString();
                    
                    break;

                case DataType.Health:

                    _heath.Health               = countChangeData;
                    _view.CountHealthText.text  = countChangeData.ToString();
                    
                    break;

                case DataType.Power:
                    
                    _power.Power                = countChangeData;
                    _view.CountPowerText.text   = countChangeData.ToString();
                    
                    break;

            }

            SetEnemyPowerText();

        }

        private void SetEnemyPowerText()
        {

            _view.CountPowerEnemyText.text = _enemy.Power.ToString();

        }

        #endregion

    }

}