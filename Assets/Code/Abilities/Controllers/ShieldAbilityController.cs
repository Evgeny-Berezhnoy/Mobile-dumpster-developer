using UnityEngine;

using Object = UnityEngine.Object;

namespace Abilities
{

    public class ShieldAbilityController : IOverridableAbility
    {

        #region Constants

        private const string _typeConvertionError   = "Couldn't apply/unapply shield ability. Receiver is not an AbilityRootView";
        private const string _missingViewError      = "Couldn't apply/unapply shield ability. Receiver does not have a filial ShieldAbilityView";

        #endregion

        #region Fields

        private ActiveAbilityPrefabModel _model;
        private ShieldAbilityView _prefab;

        #endregion

        #region Interface Properties

        public EAbilityType Type => EAbilityType.Active;
        public AbilityModel Model => _model;
        public EAbilityRecieverType RecieverType => EAbilityRecieverType.Player;
        
        #endregion

        #region Constructors

        public ShieldAbilityController(ActiveAbilityPrefabModel model)
        {

            _model  = model;
            _prefab = model.Prefab.GetComponent<ShieldAbilityView>();

        }

        #endregion

        #region Interfaces Methods

        public void Apply(IAbilityReceiver receiver)
        {

            var abilityReceiver = receiver as AbilityRootView;

            if (!abilityReceiver)
            {

                Debug.LogError(_typeConvertionError);

                return;

            };

            var shieldAbilityView = abilityReceiver.GetComponentInChildren<ShieldAbilityView>();

            if (!shieldAbilityView)
            {

                Object.Instantiate(_prefab, abilityReceiver.AbilityTransform);

            }
            else
            {

                shieldAbilityView.gameObject.SetActive(true);

            };

        }

        public void Unapply(IAbilityReceiver receiver)
        {

            var abilityReceiver = receiver as AbilityRootView;

            var shieldAbilityView = abilityReceiver.GetComponentInChildren<ShieldAbilityView>();

            if (!shieldAbilityView) return;

            shieldAbilityView.gameObject.SetActive(false);

        }

        #endregion

    }

}