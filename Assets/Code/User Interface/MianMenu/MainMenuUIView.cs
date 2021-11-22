using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{

    public class MainMenuUIView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private Button _startButton;
        [SerializeField] private Button _quitButton;

        #endregion

        #region Properties

        public Button StartButton => _startButton;
        public Button QuitButton => _quitButton;

        #endregion

    }

}