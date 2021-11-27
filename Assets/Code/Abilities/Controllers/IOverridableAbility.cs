namespace Abilities
{

    public interface IOverridableAbility : IAbility
    {

        #region Methods

        void Unapply(IAbilityReceiver receiver);
        
        #endregion

    }

}