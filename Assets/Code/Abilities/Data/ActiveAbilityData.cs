using UnityEngine;

namespace Abilities
{

    [CreateAssetMenu(fileName = "Active ability", menuName = "Abilities/Active", order = 1)]
    public class ActiveAbilityData : AbilityData
    {

        #region Fields

        [SerializeField] private EActiveAbilityEffect _effect;
        
        #endregion

        #region Properties

        public EActiveAbilityEffect Effect => _effect;
        public override EAbilityType Type => EAbilityType.Active;

        #endregion

    }

}
