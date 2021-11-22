namespace Abilities
{

    public class ActiveAbilityModel : AbilityModel
    {

        #region Fields

        protected EActiveAbilityEffect _effect;

        #endregion

        #region Properties

        public EActiveAbilityEffect Effect => _effect;

        #endregion
        
        #region Constructors

        public ActiveAbilityModel(ActiveAbilityData abilityData) : base(abilityData)
        {

            _effect = abilityData.Effect;

        }

        #endregion

    }

}