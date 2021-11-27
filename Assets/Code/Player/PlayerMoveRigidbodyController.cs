using System;
using UnityEngine;
using Abilities;
using Cars;
using Constants;
using ExtensionCompilation;
using Game;
using InputLogic;
using Interfaces;
using MVC;
using StandardObjects;

namespace Player
{

    public class PlayerMoveRigidbodyController : MoveController, IFixedUpdate, IGameStateListener, IToggleObject, IDisposableAdvanced, IAbilityReceiver
    {

        #region Fields

        private Vector2 _direction;

        private Transform _playerStartTransform;
        private BoxCollider2D _collider;
        private Rigidbody2D _rigidbody;

        private RestrictionsContactsPoller2D<BoxCollider2D> _contactsPoller;

        #endregion

        #region Interface observers

        public GameStateController CurrentGameStateController { get; private set; }

        #endregion

        #region Observers

        private BaseInput _inputController;

        #endregion

        #region Interface properties

        public bool IsDisposed { get; private set; }

        #endregion

        #region Properties

        public Rigidbody2D Rigidbody => _rigidbody;
        public RestrictionsContactsPoller2D<BoxCollider2D> ContactsPoller => _contactsPoller;

        #endregion

        #region Constructors

        public PlayerMoveRigidbodyController(Transform playerStartTransform, float speed, CarView playerView, BaseInput inputController, GameStateController gameStateController) : base(playerView.transform, speed)
        {

            _direction                      = Vector2.zero;
            
            _playerStartTransform           = playerStartTransform;
            _collider                       = playerView.Collider;
            _rigidbody                      = playerView.RigidBody;

            _contactsPoller                 = new RestrictionsContactsPoller2D<BoxCollider2D>(_collider, LayerMasks.OBSTACLES);

            _inputController                = inputController;
            _inputController.AddAxisShiftHandler(Move);

            CurrentGameStateController      = gameStateController;
            CurrentGameStateController.AddHandler(OnGameStateChange);

        }

        #endregion

        #region Base Methods

        public override void Move(Vector3 direction, float deltaTime)
        {

            _direction = direction;
            
        }

        #endregion

        #region Interfaces Methods

        public void OnFixedUpdate(float deltaTime)
        {

            if(CurrentGameStateController.State != EGameState.Play)
            {

                return;

            };

            _contactsPoller.OnFixedUpdate(deltaTime);

            var directionX = (_direction.normalized * (deltaTime * Speed)).x;

            if (directionX > 0 && !_contactsPoller.HasRightContacts)
            {

                _rigidbody.velocity = _rigidbody.velocity.Change(x: directionX);

            }
            else if (directionX < 0 && !_contactsPoller.HasLeftContacts)
            {

                _rigidbody.velocity = _rigidbody.velocity.Change(x: directionX);

            }
            else
            {

                _rigidbody.velocity = _rigidbody.velocity.Change(x: 0);

            };

            if(_rigidbody.velocity.y < Physicals2D.FALL_VELOCITY_LIMIT)
            {

                _rigidbody.velocity = _rigidbody.velocity.Change(y: Physicals2D.FALL_VELOCITY_LIMIT);

            };

            _direction = Vector2.zero;

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

        public void SwitchOff()
        {

            _inputController.RemoveAxisShiftHandler(Move);

            _rigidbody.MovePosition(_playerStartTransform.position);
            _rigidbody.bodyType = RigidbodyType2D.Static;

            _direction          = Vector2.zero;

        }

        public void SwitchOn()
        {

            _inputController.AddAxisShiftHandler(Move);

            _rigidbody.bodyType = RigidbodyType2D.Dynamic;

        }

        public virtual void Dispose()
        {

            if (IsDisposed)
            {

                return;

            };

            IsDisposed = true;

            if(_inputController != null)
            {

                _inputController.RemoveAxisShiftHandler(Move);
                
            };

            if(CurrentGameStateController != null)
            {

                CurrentGameStateController.RemoveHandler(OnGameStateChange);

            };

            GC.SuppressFinalize(this);

        }

        #endregion

    }

}