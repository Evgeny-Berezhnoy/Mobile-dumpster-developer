using System;
using System.Collections.Generic;
using UnityEngine;
using Game;
using Interfaces;
using MVC;

using Object = UnityEngine.Object;

namespace RewardSlotsDemo
{

    public class DailyRewardController : IController, IUpdate, IGameStateToggleListener, IDisposableAdvanced
    {

        #region Constants

        private const string CurrentSlotInActiveKey = nameof(CurrentSlotInActiveKey);
        private const string TimeGetRewardKey       = nameof(TimeGetRewardKey);

        #endregion
        
        #region Fields

        private DailyRewardView _view;
        private List<ContainerSlotRewardView> _slots;

        private CurrencyController _woodController;
        private CurrencyController _goldController;

        private bool _isGetReward;

        #endregion

        #region Interfaces Properties

        public GameStateController CurrentGameStateController { get; private set; }
        public bool IsDisposed { get; private set; }

        #endregion

        #region Properties

        public int CurrentSlotInActive
        {

            get => PlayerPrefs.GetInt(CurrentSlotInActiveKey, 0);
            set => PlayerPrefs.SetInt(CurrentSlotInActiveKey, value);

        }
        public DateTime? TimeGetReward
        {

            get
            {

                var data = PlayerPrefs.GetString(TimeGetRewardKey, null);

                if (!string.IsNullOrEmpty(data)) return DateTime.Parse(data);

                return null;

            }
            set
            {

                if (value != null)
                    PlayerPrefs.SetString(TimeGetRewardKey, value.ToString());
                else
                    PlayerPrefs.DeleteKey(TimeGetRewardKey);

            }

        }

        #endregion

        #region Constructors

        public DailyRewardController(RectTransform root, DailyRewardView prefab, CurrencyView currencyPrefab, ContainerSlotRewardView rewardSlotPrefab, GameStateController gameStateController)
        {

            _view = Object.Instantiate(prefab, root);

            _view.GetRewardButton.AddHandler(ClaimReward);
            _view.ResetButton.AddHandler(ResetTimer);
            _view.MainMenuButton.AddHandler(GetToMainMenu);

            InitSlots(rewardSlotPrefab);

            _woodController = new CurrencyController(_view.WoodRewardPosition, currencyPrefab, ERewardType.Wood, prefab.WoodSprite);
            _goldController = new CurrencyController(_view.GoldRewardPosition, currencyPrefab, ERewardType.Gold, prefab.GoldSprite);

            CurrentGameStateController = gameStateController;
            CurrentGameStateController.AddHandler(OnGameStateChange);

        }

        #endregion

        #region Destructors

        ~DailyRewardController()
        {

            Dispose();

        }

        #endregion

        #region Interfaces Methods

        public void OnUpdate(float deltaTime)
        {

            if(CurrentGameStateController.State != EGameState.DailyReward) return;

            RefreshRewardsState();

        }

        public void OnGameStateChange(EGameState state)
        {

            switch (state)
            {

                case EGameState.DailyReward:

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

            };

            IsDisposed = true;

            _view.GetRewardButton.Dispose();
            _view.ResetButton.Dispose();
            _view.MainMenuButton.Dispose();

            for(int i = _slots.Count - 1; i >= 0; i--)
            {

                Object.Destroy(_slots[i]);

            }

            Object.Destroy(_view);

            CurrentGameStateController?.RemoveHandler(OnGameStateChange);

            GC.SuppressFinalize(this);

        }

        #endregion

        #region Methods

        private void InitSlots(ContainerSlotRewardView prefab)
        {

            _slots = new List<ContainerSlotRewardView>();

            for (var i = 0; i < _view.Rewards.Count; i++)
            {

                var instanceSlot = Object.Instantiate(prefab, _view.MountRootSlotsReward, false);

                _slots.Add(instanceSlot);

            }

        }

        private void RefreshRewardsState()
        {

            _isGetReward = true;

            if (TimeGetReward.HasValue)
            {

                var timeSpan = DateTime.UtcNow - TimeGetReward.Value;

                if (timeSpan.Seconds > _view.TimeDeadline)
                {

                    TimeGetReward       = null;
                    CurrentSlotInActive = 0;

                }
                else if (timeSpan.Seconds < _view.TimeCooldown)
                {

                    _isGetReward = false;
                
                }

            }

            RefreshUi();

        }

        private void RefreshUi()
        {

            _view.GetRewardButton.Interactable = _isGetReward;

            if (_isGetReward)
            {

                _view.TimerNewReward.text = "The reward is received today";
                _view.GetRewardProgressBar.fillAmount = 1;

            }
            else
            {

                if (TimeGetReward != null)
                {

                    var nextClaimTime           = TimeGetReward.Value.AddSeconds(_view.TimeCooldown);
                    var currentClaimCooldown    = nextClaimTime - DateTime.UtcNow;
                    var timeGetReward           = $"{currentClaimCooldown.Days:D2}:{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

                    _view.TimerNewReward.text               = $"Time to get the next reward: {timeGetReward}";
                    _view.GetRewardProgressBar.fillAmount   = (_view.TimeCooldown - (float) currentClaimCooldown.TotalSeconds) / _view.TimeCooldown;

                }

            }

            for (var i = 0; i < _slots.Count; i++)
            {

                _slots[i].SetData(_view.Rewards[i], i + 1, i == CurrentSlotInActive);
            
            }

        }

        private void ClaimReward()
        {

            if (!_isGetReward) return;

            var reward = _view.Rewards[CurrentSlotInActive];

            switch (reward.RewardType)
            {

                case ERewardType.Wood:
                    
                    _woodController.Amount += reward.CountCurrency;
                    
                    break;

                case ERewardType.Gold:

                    _goldController.Amount += reward.CountCurrency;
                    
                    break;

            }

            TimeGetReward         = DateTime.UtcNow;
            CurrentSlotInActive   = (CurrentSlotInActive + 1) % _view.Rewards.Count;

            RefreshRewardsState();

        }

        private void ResetTimer()
        {

            PlayerPrefs.DeleteAll();

        }

        private void GetToMainMenu()
        {

            CurrentGameStateController.State = EGameState.MainMenu;

        }

        #endregion

    }

}