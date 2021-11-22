namespace Abilities
{

    public interface IAbility
    {

        #region Fields
        
        AbilityModel Model { get; }
        EAbilityType Type { get; }
        EAbilityRecieverType RecieverType { get; }

        #endregion

        #region Methods

        void Apply(IAbilityReceiver receiver);
        
        #endregion

    }

}