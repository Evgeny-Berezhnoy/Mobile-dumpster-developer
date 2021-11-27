using UnityEngine;

namespace Abilities
{

    [CreateAssetMenu(fileName = "Passive ability", menuName = "Abilities/Passive", order = 3)]
    public class PassiveAbilityData : AbilityData
    {

        #region Fields

        [SerializeField] private EPassiveAbilityEffect _effect;

        #endregion

        #region Properties

        public EPassiveAbilityEffect Effect => _effect;
        public override EAbilityType Type => EAbilityType.Passive;
        
        #endregion

    }

}