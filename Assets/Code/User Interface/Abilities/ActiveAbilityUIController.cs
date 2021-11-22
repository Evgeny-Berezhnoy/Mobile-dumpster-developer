using UnityEngine;
using UnityEngine.Events;

namespace UserInterface
{

    public class ActiveAbilityUIController : PassiveAbilityUIController<UIButton>
    {

        #region Constants

        private const string _typeConvertionError = "Couldn't handle chain button. Transfered data is not an AbilitySlidingSlotData";

        #endregion

        #region Fields

        private bool _abilityIsApplied;

        #endregion

        #region Constructors

        public ActiveAbilityUIController(RectTransform root, UIButton prefab, AbilityUIData data) : base(root, prefab)
        {

            _view.Button.onClick.AddListener(new UnityAction(Init));

            Init(data);

        }

        #endregion

        #region Destructors

        ~ActiveAbilityUIController()
        {

            Dispose();

        }

        #endregion

        #region Base Properties

        public override IButtonChain Handle(IButtonChainData data)
        {

            var abilityData = data as AbilityUIData;

            if (abilityData == null)
            {

                _data               = null;

                _view.Image.sprite  = null;

                Debug.LogError(_typeConvertionError);

            }
            else
            {

                Init(abilityData);

            };

            return null;

        }

        public override void Init(AbilityUIData data)
        {

            TryUnapply();

            _data               = data;
            _view.Image.sprite  = data.Sprite;

            _abilityIsApplied   = false;

        }

        public override void Init()
        {

            if (!TryUnapply())
            {

                _data?.ApplyAction?.Invoke();
                
                _abilityIsApplied = true;

            };

        }

        public override void Dispose()
        {

            if(IsDisposed)
            {

                return;

            };

            _view.Button.onClick.RemoveAllListeners();

            base.Dispose();

        }

        private bool TryUnapply()
        {

            if (_abilityIsApplied
                && _data != null
                && _data.IsRevertable)
            {

                _data?.UnapplyAction?.Invoke();

                _abilityIsApplied = false;

                return true;

            };

            return false;

        }

        #endregion

    }

}