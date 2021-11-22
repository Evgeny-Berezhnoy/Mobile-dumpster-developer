using System;
using UnityEngine;
using Abilities;
using Cars;
using ExtensionCompilation;
using Game;
using InputLogic;
using Interfaces;
using MVC;

using Object = UnityEngine.Object;

namespace Player
{

    public class PlayerController : IController, IFixedUpdate, IToggleObject, IGameStateListener, IDisposableAdvanced, IAbilityReceiver
    {

        #region Fields

        private CarView _view;
        private PlayerMoveRigidbodyController _playerMoveController;

        #endregion

        #region Interfaces properties

        public bool IsDisposed { get; private set; }
        
        #endregion

        #region Interfaces observers

        public GameStateController CurrentGameStateController { get; private set; }

        #endregion

        #region Constructors

        public PlayerController(Transform playerTransform, CarModel carModel, BaseInput inputController, AbilityUISubscriber abilityUISubscriber, GameStateController gameStateController)
        {

            _view = Object.Instantiate(carModel.View);
            _view.gameObject.transform.SetPositionAndRotation(playerTransform);

            var cameraTransform = Camera.main.transform;

            cameraTransform.SetParent(_view.CameraTransform);
            cameraTransform.SetLocalPositionAndRotation();

            CurrentGameStateController = gameStateController;
            
            _playerMoveController   = new PlayerMoveRigidbodyController(playerTransform, carModel.Speed, _view, inputController, gameStateController);

            abilityUISubscriber.SubscribeReceiver(EAbilityRecieverType.Player, _view);
            abilityUISubscriber.SubscribeReceiver(EAbilityRecieverType.PlayerMovement, _playerMoveController);

        }

        #endregion

        #region Destructors

        ~PlayerController()
        {

            Dispose();

        }

        #endregion

        #region Interfaces Methods

        public void SwitchOff()
        {

            _view.gameObject.SetActive(false);

        }

        public void SwitchOn()
        {

            _view.gameObject.SetActive(true);

        }

        public void OnGameStateChange(EGameState state)
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

        public void OnFixedUpdate(float deltaTime)
        {

            if(CurrentGameStateController.State != EGameState.Play)
            {

                return;

            };

            _playerMoveController.OnFixedUpdate(deltaTime);

        }

        public virtual void Dispose()
        {

            if (IsDisposed)
            {

                return;

            };

            IsDisposed = true;

            Object.Destroy(_view);

            GC.SuppressFinalize(this);

        }

        #endregion

    }

}