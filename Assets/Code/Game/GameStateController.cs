using System.Linq;
using UnityEngine;
using Interfaces;
using MVC;
using ProjectAnalytics;

using static Constants.Delegates;

namespace Game
{

    public class GameStateController : IController, IEventHandler<GameStateChange>, IAnalysable, IDisposableAdvanced
    {

        #region Events

        private event GameStateChange _onGameStateChange;

        #endregion

        #region Fields

        private EGameState _state;

        private readonly IAnalyticalTool _analyticalTool;

        #endregion

        #region Interfaces properties

        public IAnalyticalTool AnalyticalTool => _analyticalTool;
        public bool IsDisposed { get; private set; }
        
        #endregion

        #region Properties

        public EGameState State
        {
            
            get => _state;
            set
            {

                _state = value;

                _onGameStateChange?.Invoke(_state);

                if (_state == EGameState.Play)
                {

                    _analyticalTool.InvokeAnalyticalEvent(AnalyticalEvents.GAME_STARTED);

                }
                else if (_state == EGameState.Quit)
                {

                    Dispose();

                    QuitGame();

                };

            }

        }

        #endregion

        #region Constructors

        public GameStateController()
        {

            _state          = EGameState.MainMenu;
            _analyticalTool = new AnalyticalTool();

        }

        #endregion

        #region Destructors

        ~GameStateController()
        {

            Dispose();

        }

        #endregion

        #region Interfaces Methods

        public void AddHandler(GameStateChange handler)
        {

            _onGameStateChange += handler;

        }

        public void RemoveHandler(GameStateChange handler)
        {

            _onGameStateChange -= handler;
            
        }

        public void RemoveAllHandlers()
        {
            
            var handlers =
                _onGameStateChange
                    ?.GetInvocationList()
                    .ToList()
                    .Cast<GameStateChange>()
                    .ToList();

            if (handlers == null)
            {

                return;

            };

            for (int i = 0; i < handlers.Count; i++)
            {

                _onGameStateChange -= handlers[i];

            };

        }

        public void Dispose()
        {

            if (IsDisposed)
            {

                return;

            };

            IsDisposed = true;

            RemoveAllHandlers();

        }

        #endregion

        #region Methods

        private void QuitGame()
        {

            #if UNITY_EDITOR
                
                UnityEditor.EditorApplication.isPlaying = false;
            
            #else
            
                Application.Quit();
                
            #endif

        }

        #endregion

    }

}