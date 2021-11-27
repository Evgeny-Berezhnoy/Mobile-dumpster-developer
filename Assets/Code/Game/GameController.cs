using UnityEngine;
using Abilities;
using InputLogic;
using MVC;
using Player;
using ProjectAdvertisement;
using UserInterface;

namespace Game
{

    public class GameController : MonoBehaviour
    {

        #region Fields

        [Header("Root transforms")]
        [SerializeField] private Transform _player;
        [SerializeField] private RectTransform _userIntreface;

        [Header("Prefabs")]
        [SerializeField] private GameConfiguration _configuration;

        [Header("Input")]
        [SerializeField] private EInputMode _inputMode;


        private GameModel _gameModel;
        
        private ControllersList _controllersList;

        private UIInitializer _uiInitializer;
        private InputInitializer _inputInitializer;
        private PlayerInitializer _playerInitializer;

        private AdvertisementDispayer _advertisementDispayer;

        #endregion


        #region Unity Events

        private void Start()
        {

            var gameStateController     = new GameStateController();

            _gameModel                  = new GameModel(_configuration, _inputMode);

            _controllersList            = new ControllersList();

            var abilityRepository       = new AbilityRepository(_gameModel.Abilities);
            var abilityUISubscriber     = new AbilityUISubscriber(abilityRepository.Abilities);

            _uiInitializer              = new UIInitializer(_userIntreface, _gameModel, abilityUISubscriber, gameStateController);
            _inputInitializer           = new InputInitializer(_controllersList, _inputMode, _uiInitializer.GameplayUIView);
            _playerInitializer          = new PlayerInitializer(_controllersList, _player, _gameModel.PlayerCar, _inputInitializer.InputController, abilityUISubscriber, gameStateController);

            _advertisementDispayer      = new AdvertisementDispayer(gameStateController);

            gameStateController.State   = EGameState.MainMenu;

        }

        private void Update()
        {

            _controllersList.OnUpdate(Time.deltaTime);

        }

        private void FixedUpdate()
        {

            _controllersList.OnFixedUpdate(Time.fixedDeltaTime);

        }

        #endregion

    }

}