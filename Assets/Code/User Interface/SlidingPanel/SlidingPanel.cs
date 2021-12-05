using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{

    public class SlidingPanel : MonoBehaviour
    {

        #region Fields

        [SerializeField] private float _slideDelay;
        [SerializeField] private RectTransform _slotsPanel;
        [SerializeField] private Button _hideShowButton;
        [SerializeField] private Button _slideBackButton;
        [SerializeField] private List<UIButton> _slots;
        [SerializeField] private Button _slideForthButton;

        #endregion

        #region Properties

        public float SlideDelay => _slideDelay;
        public RectTransform SlotsPanel => _slotsPanel;
        public Button HideShowButton => _hideShowButton;
        public Button SlideBackButton => _slideBackButton;
        public List<UIButton> Slots => _slots;
        public Button SlideForthButton => _slideForthButton;
        public float SlideDistance
        {

            get => (transform.position - _slotsPanel.position).x;

        } 

        #endregion

    }

}