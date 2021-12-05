using System.Collections.Generic;
using UnityEngine;
using Abilities;
using AIDemo;
using Game;
using MVC;
using RewardSlotsDemo;

namespace UserInterface
{
    class UIInitializer
    {

        #region Fields

        private MainMenuUIController _mainMenuController;
        private GameplayUIController _gameplayController;
        private FightUIController _fightController;
        private DailyRewardController _dailyRewardController;
        private SlidingPanelController<UIButton, AbilityUIData> _abilitiesSlidingPanelController;
        private PassiveAbilityUIController<UIImage> _passiveAbility;
        private ActiveAbilityUIController _activeAbility;

        #endregion

        #region Properties

        public IGameplayUIView GameplayUIView => _gameplayController.View;

        #endregion

        #region Constructors

        public UIInitializer(
            ControllersList controllersList,
            RectTransform root, 
            GameModel gameModel,
            AbilityUISubscriber abilityUISubscriber,
            GameStateController gameStateController)
        {

            _mainMenuController     = new MainMenuUIController(root, gameModel.MainMenu, gameStateController);
            _gameplayController     = new GameplayUIController(root, gameModel.GameplayInterface, gameStateController);
            _fightController        = new FightUIController(root, gameModel.FightWindow, gameStateController);
            _dailyRewardController  = new DailyRewardController(root, gameModel.RewardsWindow, gameModel.CurrencySlot, gameModel.ContainerSlotReward, gameStateController);
            _passiveAbility         = new PassiveAbilityUIController<UIImage>(_gameplayController.Root, gameModel.PassiveAbilityIcon);
            _activeAbility          = new ActiveAbilityUIController(_gameplayController.Root, gameModel.ActiveAbilityButton, abilityUISubscriber.StartActiveAbilityData);
            
            var slotControllers     = new List<SlidingSlotController<UIButton, AbilityUIData>>();
            
            _abilitiesSlidingPanelController
                = new AbilitiesSlidingPanelController(
                    _gameplayController.Root, 
                    gameModel.SlidingPanel,
                    abilityUISubscriber.AbilityUIDatas, 
                    new AbilitySlidingSlotControllerBuilder(), 
                    gameStateController,
                    slotControllers,
                    _passiveAbility,
                    _activeAbility);

            controllersList.AddController(_dailyRewardController);

        }

        #endregion

    }

}