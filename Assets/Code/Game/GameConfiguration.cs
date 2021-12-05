﻿using UnityEngine;

namespace Game
{

    [CreateAssetMenu(menuName = "Configurations/Game", fileName = "Game configuration", order = 0)]
    public class GameConfiguration : ScriptableObject
    {

        #region Fields

        [SerializeField] private string _player;
        [SerializeField] private string _abilitiesCollection;
        
        [Header("User Interface")]
        [SerializeField] private string _gameplayView;
        [SerializeField] private string _gameplayJoystickView;
        [SerializeField] private string _mainMenuView;
        [SerializeField] private string _fightWindow;
        [SerializeField] private string _rewardsWindow;
        [SerializeField] private string _currencySlot;
        [SerializeField] private string _containerSlotRewardView;
        [SerializeField] private string _slidingPanel;
        [SerializeField] private string _passiveAbilityIcon;
        [SerializeField] private string _activeAbilityButton;
        
        #endregion

        #region Properties

        public string Player => _player;
        public string AbilitiesCollection => _abilitiesCollection;
        public string GameplayView => _gameplayView;
        public string GameplayJoystickView => _gameplayJoystickView;
        public string MainMenuView => _mainMenuView;
        public string FightView => _fightWindow;
        public string RewardsWindow => _rewardsWindow;
        public string CurrencySlot => _currencySlot;
        public string ContainerSlotRewardView => _containerSlotRewardView;
        public string SlidingPanel => _slidingPanel;
        public string PassiveAbilityIcon => _passiveAbilityIcon;
        public string ActiveAbilityButton => _activeAbilityButton;

        #endregion

    }

}