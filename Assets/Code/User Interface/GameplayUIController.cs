using System;
using UnityEngine;
using Game;
using Interfaces;
using MVC;

using Object = UnityEngine.Object;

namespace UserInterface
{

    public class GameplayUIController : IController, IGameStateListener, IToggleObject, IDisposableAdvanced
    {

        #region Fields

        private GameplayUIView _view;

        #endregion

        #region Properties

        public IGameplayUIView View => _view;

        #endregion

        #region Interfaces Properties

        public GameStateController CurrentGameStateController { get; private set; }

        public bool IsDisposed { get; private set; }

        #endregion

        #region Constructors

        public GameplayUIController(Transform root, GameplayUIView viewPrefab, GameStateController gameStateController)
        {

            _view = Object.Instantiate(viewPrefab, root);

            CurrentGameStateController = gameStateController;
            CurrentGameStateController.AddHandler(OnGameStateChange);

            _view.EndButton.onClick.AddListener(() =>
            {

                CurrentGameStateController.State = EGameState.MainMenu;

            });
            
        }

        #endregion

        #region Destructors

        ~GameplayUIController()
        {

            Dispose();

        }

        #endregion

        #region Interfaces Methods

        public virtual void OnGameStateChange(EGameState state)
        {

            switch (state)
            {

                case EGameState.Play:

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

        public virtual void SwitchOff()
        {

            _view.gameObject.SetActive(false);

        }

        public virtual void SwitchOn()
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

            _view.EndButton.onClick.RemoveAllListeners();

            Object.Destroy(_view);

            GC.SuppressFinalize(this);

        }

        #endregion

    }

}