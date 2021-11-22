using UnityEngine;

namespace Abilities
{

    public class AbilityRootView : MonoBehaviour, IAbilityRootView
    {

        #region Fields

        [SerializeField] private Transform _abilityTransform;

        #endregion

        #region Properties

        public Transform AbilityTransform => _abilityTransform;

        #endregion

    }

}