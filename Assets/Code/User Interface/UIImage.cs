using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{

    [RequireComponent(typeof(Image))]
    public class UIImage : MonoBehaviour
    {

        #region Fields

        [SerializeField] private Image _image;

        #endregion

        #region Properties

        public Image Image => _image;

        #endregion

    }

}
