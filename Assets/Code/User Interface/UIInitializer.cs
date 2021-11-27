using System.Collections.Generic;
using UnityEngine;
using Abilities;
using Game;

namespace UserInterface
{
    class UIInitializer
    {

        #region Fields

        private MainMenuUIController _mainMenuController;
        private GameplayUIController _gameplayController;
        private SlidingPanelController<UIButton, AbilityUIData> _abilitiesSlidingPanelController;
        private PassiveAbilityUIController<UIImage> _passiveAbility;
        private ActiveAbilityUIController _activeAbility;

        #endregion

        #region Properties

        public IGameplayUIView GameplayUIView => _gameplayController.View;

        #endregion

        #region Constructors

        public UIInitializer(
            RectTransform root, 
            GameModel gameModel,
            AbilityUISubscriber abilityUISubscriber,
            GameStateController gameStateController)
        {

            _mainMenuController     = new MainMenuUIController(root, gameModel.MainMenu, gameStateController);
            _gameplayController     = new GameplayUIController(root, gameModel.GameplayInterface, gameStateController);
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

        }

        #endregion

    }

}