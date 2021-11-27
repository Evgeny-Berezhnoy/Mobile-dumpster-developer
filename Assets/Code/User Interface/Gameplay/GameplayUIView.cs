using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{

    public class GameplayUIView : MonoBehaviour, IGameplayUIView
    {

        #region Fields

        [SerializeField] private Button _endButton;

        #endregion

        #region Properties

        public Button EndButton => _endButton;

        #endregion

    }

}