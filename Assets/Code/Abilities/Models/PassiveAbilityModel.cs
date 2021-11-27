namespace Abilities
{

    public class PassiveAbilityModel : AbilityModel
    {

        #region Fields

        protected EPassiveAbilityEffect _effect;

        #endregion

        #region Properties

        public EPassiveAbilityEffect Effect => _effect;

        #endregion

        #region Constructors

        public PassiveAbilityModel(PassiveAbilityData abilityData) : base(abilityData)
        {

            _effect = abilityData.Effect;

        }

        #endregion

    }

}