using UnityEngine;

namespace UserInterface
{

    public class MainMenuUIView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private TweenButton _startButton;
        [SerializeField] private TweenButton _quitButton;
        [SerializeField] private TweenButton _rewardsButton;

        #endregion

        #region Properties

        public TweenButton StartButton => _startButton;
        public TweenButton QuitButton => _quitButton;
        public TweenButton RewardsButton => _rewardsButton;

        #endregion

    }

}