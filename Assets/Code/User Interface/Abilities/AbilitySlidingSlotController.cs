using UnityEngine;

namespace UserInterface
{

    public class AbilitySlidingSlotController : SlidingSlotController<UIButton, AbilityUIData>, IButtonChain
    {

        #region Fields

        private UIButton _view;
        private IButtonChain _nextHandler;
        
        #endregion

        #region Interfaces Propterties

        public AbilityUIData SlotData { get; private set; }

        #endregion

        #region Constructors

        public AbilitySlidingSlotController(UIButton view, AbilityUIData slotData) : base(view, slotData)
        {

            _view = view;
            _view.Button.onClick.AddListener(OnSlotClick);

            SetSlotData(slotData);

        }

        public AbilitySlidingSlotController(UIButton view) : base(view)
        {

            _view = view;
            _view.Button.onClick.AddListener(OnSlotClick);

        }
        
        #endregion

        #region Destructors

        ~AbilitySlidingSlotController()
        {

            Dispose();

        }

        #endregion

        #region Base Methods

        public override void SetSlotData(AbilityUIData slotdata)
        {

            _view.Image.color   = new Color(_view.Image.color.r, _view.Image.color.g, _view.Image.color.b, 1);
            _view.Image.sprite  = slotdata.Sprite;

            SlotData            = slotdata;

        }

        public override void SetSlotData()
        {

            _view.Image.color   = new Color(_view.Image.color.r, _view.Image.color.g, _view.Image.color.b, 0); 
            _view.Image.sprite  = null;

            SlotData            = null;

        }
        
        #endregion

        #region Interfaces Methods

        public virtual IButtonChain Handle(IButtonChainData data)
        {

            if (_nextHandler != null)
            {

                _nextHandler.Handle(data);

            };

            return _nextHandler;

        }

        public virtual IButtonChain SetNext(IButtonChain buttonChain)
        {

            _nextHandler = buttonChain;

            return _nextHandler;

        }

        public override void Dispose()
        {

            if (IsDisposed)
            {

                return;

            }

            _view.Button.onClick.RemoveAllListeners();

            base.Dispose();

        }

        #endregion

        #region Methods

        private void OnSlotClick()
        {

            Handle(SlotData);

        }

        #endregion

    }

}
