namespace Game
{

    public interface IGameStateListener
    {

        #region Properties

        GameStateController CurrentGameStateController { get; }        

        #endregion

        #region Methods

        void OnGameStateChange(EGameState state);

        #endregion

    }

}