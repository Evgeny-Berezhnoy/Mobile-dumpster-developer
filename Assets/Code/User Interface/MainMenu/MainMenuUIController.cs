using System;
using UnityEngine;
using Game;
using Interfaces;
using MVC;

using Object = UnityEngine.Object;

namespace UserInterface
{

    class MainMenuUIController : IController, IGameStateToggleListener, IDisposableAdvanced
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

            _view.StartButton.AddHandler(() =>
            {

                CurrentGameStateController.State = EGameState.Play;

            });

            _view.QuitButton.AddHandler(() =>
            {

                CurrentGameStateController.State = EGameState.Quit;

            });

            _view.RewardsButton.AddHandler(() =>
            {

                CurrentGameStateController.State = EGameState.DailyReward;

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

            _view.StartButton.Dispose();
            _view.QuitButton.Dispose();
            _view.RewardsButton.Dispose();
            
            Object.Destroy(_view);

            CurrentGameStateController?.RemoveHandler(OnGameStateChange);
            
            GC.SuppressFinalize(this);

        }

        #endregion

    }

}