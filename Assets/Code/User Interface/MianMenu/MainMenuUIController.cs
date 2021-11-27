using System;
using UnityEngine;
using Game;
using Interfaces;
using MVC;

using Object = UnityEngine.Object;

namespace UserInterface
{

    class MainMenuUIController : IController, IGameStateListener, IToggleObject, IDisposableAdvanced
    {

        #region Fields

        private MainMenuUIView _view;

        #endregion

        #region Interfaces observers

        public GameStateController CurrentGameStateController { get; protected set; }

        #endregion

        #region Interfaces properties

        public bool IsDisposed { get; private set; }

        #endregion

        #region Constructors

        public MainMenuUIController(RectTransform root, MainMenuUIView viewPrefab, GameStateController gameStateController)
        {

            _view = Object.Instantiate(viewPrefab, root);

            CurrentGameStateController = gameStateController;
            CurrentGameStateController.AddHandler(OnGameStateChange);

            _view.StartButton.onClick.AddListener(() =>
            {

                CurrentGameStateController.State = EGameState.Play;

            });

            _view.QuitButton.onClick.AddListener(() =>
            {

                CurrentGameStateController.State = EGameState.Quit;

            });
            
        }

        #endregion

        #region Destructors

        ~MainMenuUIController()
        {

            Dispose();

        }

        #endregion

        #region Interfaces Methods

        public void OnGameStateChange(EGameState state)
        {

            switch (state)
            {

                case EGameState.MainMenu:

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

        public virtual void Dispose()
        {

            if (IsDisposed)
            {

                return;

            };

            IsDisposed = true;

            if(CurrentGameStateController != null)
            {

                CurrentGameStateController.RemoveHandler(OnGameStateChange);
                
            };

            _view.StartButton.onClick.RemoveAllListeners();
            _view.QuitButton.onClick.RemoveAllListeners();
            
            Object.Destroy(_view);

            GC.SuppressFinalize(this);

        }

        #endregion

    }

}