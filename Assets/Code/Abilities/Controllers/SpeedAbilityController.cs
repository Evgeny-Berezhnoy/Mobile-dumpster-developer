using UnityEngine;
using Player;

namespace Abilities
{

    public class SpeedAbilityController : IOverridableAbility
    {

        #region Constants

        private const string _typeConvertionError = "Couldn't apply speed ability. Receiver is not a PlayerMoveRigidbodyController";

        #endregion

        #region Fields

        private PassiveAbilityModel _model;

        #endregion

        #region Interface Properties

        public AbilityModel Model => _model;
        public EAbilityType Type => EAbilityType.Passive;
        public EAbilityRecieverType RecieverType => EAbilityRecieverType.PlayerMovement;
        
        #endregion

        #region Constructors

        public SpeedAbilityController(PassiveAbilityModel model)
        {

            _model = model;
            
        }

        #endregion

        #region Interfaces Methods

        public void Apply(IAbilityReceiver receiver)
        {

            var playerRigidbodyMoveController = receiver as PlayerMoveRigidbodyController;

            if (playerRigidbodyMoveController == null)
            {

                Debug.LogError(_typeConvertionError);

                return;

            };

            playerRigidbodyMoveController.Speed += _model.Value;

        }

        public void Unapply(IAbilityReceiver receiver)
        {

            var playerRigidbodyMoveController = receiver as PlayerMoveRigidbodyController;

            if (playerRigidbodyMoveController == null)
            {

                Debug.LogError(_typeConvertionError);

                return;

            };

            playerRigidbodyMoveController.Speed -= _model.Value;

        }

        #endregion

    }

}