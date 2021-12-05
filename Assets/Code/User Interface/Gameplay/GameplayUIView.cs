using UnityEngine;

namespace UserInterface
{

    public class GameplayUIView : MonoBehaviour, IGameplayUIView
    {

        #region Fields

        [SerializeField] private TweenButton _endButton;
        [SerializeField] private TweenButton _fightButton;

        #endregion

        #region Properties

        public TweenButton EndButton => _endButton;
        public TweenButton FightButton => _fightButton;

        #endregion

    }

}