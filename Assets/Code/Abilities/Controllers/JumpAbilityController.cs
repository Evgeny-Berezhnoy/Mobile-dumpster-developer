using UnityEngine;
using Player;

namespace Abilities
{

    public class JumpAbilityController : IAbility
    {
        
        #region Constants

        private const string _typeConvertionError = "Couldn't apply jump ability. Receiver is not a PlayerMoveRigidbodyController";

        #endregion

        #region Fields

        private ActiveAbilityModel _model;

        #endregion

        #region Interface Properties

        public AbilityModel Model => _model;
        public EAbilityType Type => EAbilityType.Active;
        public EAbilityRecieverType RecieverType => EAbilityRecieverType.PlayerMovement;

        #endregion

        #region Constructors

        public JumpAbilityController(ActiveAbilityModel model)
        {

            _model = model;

        }

        #endregion

        #region Interfaces Methods

        public void Apply(IAbilityReceiver receiver)
        {

            var playerRigidbodyMoveController = receiver as PlayerMoveRigidbodyController;

            if(playerRigidbodyMoveController == null)
            {

                Debug.LogError(_typeConvertionError);

                return;

            };

            if (playerRigidbodyMoveController.ContactsPoller.OnTheGround)
            {

                playerRigidbodyMoveController.Rigidbody.AddForce(new Vector2(0, _model.Value));

            };

        }

        #endregion

    }

}