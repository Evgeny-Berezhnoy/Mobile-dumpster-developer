using UnityEngine;
using Game;
using InputLogic;

namespace UserInterface
{
    class UIInitializer
    {

        #region Fields

        private MainMenuUIController _mainMenuController;
        private GameplayUIController _gameplayController;

        #endregion

        #region Properties

        public IGameplayUIView GameplayUIView => _gameplayController.View;

        #endregion

        #region Constructors

        public UIInitializer(Transform root, GameModel gameModel, GameStateController gameStateController)
        {

            _mainMenuController = new MainMenuUIController(root, gameModel.MainMenu, gameStateController);
            _gameplayController = new GameplayUIController(root, gameModel.GameplayInterface, gameStateController);

        }

        #endregion
        
    }

}