using UnityEngine;

namespace Game
{

    [CreateAssetMenu(menuName = "Configurations/Game", fileName = "Game configuration", order = 0)]
    public class GameConfiguration : ScriptableObject
    {

        #region Fields

        [SerializeField] private string _player;

        [Header("User Interface")]
        [SerializeField] private string _gameplayView;
        [SerializeField] private string _gameplayJoystickView;
        [SerializeField] private string _mainMenuView;

        #endregion

        #region Properties

        public string Player => _player;
        public string GameplayView => _gameplayView;
        public string GameplayJoystickView => _gameplayJoystickView;
        public string MainMenuView => _mainMenuView;

        #endregion
        
    }

}