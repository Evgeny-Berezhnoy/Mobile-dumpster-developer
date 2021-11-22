using UnityEngine;
using Abilities;
using Cars;
using Game;
using InputLogic;
using MVC;

namespace Player
{

    public class PlayerInitializer
    {

        #region Fields
        
        private PlayerController _playerController;

        #endregion

        #region Constructors

        public PlayerInitializer(ControllersList controllersList, Transform playerTransform, CarModel carModel, BaseInput inputController, AbilityUISubscriber abilityUISubscriber, GameStateController gameStateController)
        {

            _playerController = new PlayerController(playerTransform, carModel, inputController, abilityUISubscriber, gameStateController);

            controllersList.AddController(_playerController);

        }

        #endregion

    }

}