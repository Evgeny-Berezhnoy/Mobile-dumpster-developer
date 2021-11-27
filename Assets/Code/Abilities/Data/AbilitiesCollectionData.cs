using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{

    [CreateAssetMenu(fileName = "Abilities collection", menuName = "Abilities/Collection", order = 0)]
    public class AbilitiesCollectionData : ScriptableObject
    {

        #region Fields

        [SerializeField] private List<AbilityData> _abilities;

        #endregion

        #region Properties

        public List<AbilityData> Abilities => _abilities;

        #endregion

    }

}