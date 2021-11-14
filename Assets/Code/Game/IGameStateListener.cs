namespace Game
{

    interface IGameStateListener
    {

        #region Properties

        GameStateController CurrentGameStateController { get; }        

        #endregion

        #region Methods

        void OnGameStateChange(EGameState state);

        #endregion

    }

}