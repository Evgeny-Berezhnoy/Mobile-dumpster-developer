using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{

    [RequireComponent(typeof(Button))]
    public class UIButton : UIImage
    {

        #region Fields

        [SerializeField] private Button _button;

        #endregion

        #region Properties

        public Button Button => _button;

        #endregion

    }

}