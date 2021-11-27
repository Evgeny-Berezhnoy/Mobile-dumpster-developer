using System.Collections.Generic;
using Abilities;
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
        private AbilitiesCollectionModel _abilitiesCollection;

        private MainMenuUIView _mainMenu;
        private GameplayUIView _gameplayInterface;
        private SlidingPanel _slidingPanel;
        private UIImage _passiveAbilityIcon;
        private UIButton _activeAbilityButton;

        #endregion

        #region Properties

        public CarModel PlayerCar => _playerCar;
        public List<AbilityModel> Abilities => _abilitiesCollection.Models;
        public MainMenuUIView MainMenu => _mainMenu;
        public GameplayUIView GameplayInterface => _gameplayInterface;
        public SlidingPanel SlidingPanel => _slidingPanel;
        public UIImage PassiveAbilityIcon => _passiveAbilityIcon;
        public UIButton ActiveAbilityButton => _activeAbilityButton;

        #endregion

        #region Constructors

        public GameModel(GameConfiguration configuration, EInputMode inputMode)
        {

            var carConfiguration        = ResourceLoader.LoadObject<CarConfiguration>(configuration.Player);
            var AbilitiesCollectionData = ResourceLoader.LoadObject<AbilitiesCollectionData>(configuration.AbilitiesCollection);

            _playerCar                  = new CarModel(carConfiguration);
            _abilitiesCollection        = new AbilitiesCollectionModel(AbilitiesCollectionData);

            _mainMenu                   = ResourceLoader.LoadComponent<MainMenuUIView>(configuration.MainMenuView);
            _slidingPanel               = ResourceLoader.LoadComponent<SlidingPanel>(configuration.SlidingPanel);
            _passiveAbilityIcon         = ResourceLoader.LoadComponent<UIImage>(configuration.PassiveAbilityIcon);
            _activeAbilityButton        = ResourceLoader.LoadComponent<UIButton>(configuration.ActiveAbilityButton);

            if (inputMode == EInputMode.Joystick)
            {

                _gameplayInterface      = ResourceLoader.LoadComponent<GameplayUIView>(configuration.GameplayJoystickView);

            }
            else
            {

                _gameplayInterface      = ResourceLoader.LoadComponent<GameplayUIView>(configuration.GameplayView);

            };

        }

        #endregion

    }

}