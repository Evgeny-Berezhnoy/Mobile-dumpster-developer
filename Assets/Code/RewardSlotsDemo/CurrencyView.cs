using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RewardSlotsDemo
{

    public class CurrencyView : MonoBehaviour
    {

        #region Fields

        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _currentCount;

        #endregion

        #region Properties

        public Image Image => _image;
        public TMP_Text CurrentCount => _currentCount;

        #endregion

    }

}