using System;
using UnityEngine;
using Game;
using Interfaces;
using MVC;

using Object = UnityEngine.Object;

namespace UserInterface
{

    public class GameplayUIController : IController, IGameStateToggleListener, IDisposableAdvanced
    {

        #region Fields

        private GameplayUIView _view;

        #endregion

        #region Properties

        public IGameplayUIView View => _view;
        public RectTransform Root => (RectTransform)_view.transform;

        #endregion

        #region Interfaces Properties

        public GameStateController CurrentGameStateController { get; private set; }

        public bool IsDisposed { get; private set; }

        #endregion

        #region Constructors

        public GameplayUIController(RectTransform root, GameplayUIView viewPrefab, GameStateController gameStateController)
        {

            _view = Object.Instantiate(viewPrefab, root);

            CurrentGameStateController = gameStateController;
            CurrentGameStateController.AddHandler(OnGameStateChange);

            _view.EndButton.AddHandler(() =>
            {

                CurrentGameStateController.State = EGameState.MainMenu;

            });

            _view.FightButton.AddHandler(() =>
            {

                CurrentGameStateController.State = EGameState.Fight;
                
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

            CurrentGameStateController?.RemoveHandler(OnGameStateChange);
            
            _view.EndButton.Dispose();
            _view.FightButton.Dispose();
            
            Object.Destroy(_view);

            GC.SuppressFinalize(this);

        }

        #endregion

    }

}