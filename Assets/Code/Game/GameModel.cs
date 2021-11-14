using Cars;
using InputLogic;
using Models;
using UserInterface;

namespace Game
{

    public class GameModel
    {

        #region Fields

        private CarModel _playerCar;
        private MainMenuUIView _mainMenu;
        private GameplayUIView _gameplayInterface;

        #endregion

        #region Properties

        public CarModel PlayerCar => _playerCar;
        public MainMenuUIView MainMenu => _mainMenu;
        public GameplayUIView GameplayInterface => _gameplayInterface;
        
        #endregion

        #region Constructors

        public GameModel(GameConfiguration configuration, EInputMode inputMode)
        {

            var carConfiguration    = ResourceLoader.LoadObject<CarConfiguration>(configuration.Player);

            _playerCar              = new CarModel(carConfiguration);

            _mainMenu               = ResourceLoader.LoadComponent<MainMenuUIView>(configuration.MainMenuView);

            if (inputMode == EInputMode.Joystick)
            {

                _gameplayInterface = ResourceLoader.LoadComponent<GameplayUIView>(configuration.GameplayJoystickView);

            }
            else
            {

                _gameplayInterface = ResourceLoader.LoadComponent<GameplayUIView>(configuration.GameplayView);

            };

        }

        #endregion

    }

}