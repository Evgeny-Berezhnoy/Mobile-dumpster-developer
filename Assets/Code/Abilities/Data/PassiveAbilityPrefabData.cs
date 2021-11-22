using UnityEngine;
using Interfaces;

namespace Abilities
{

    [CreateAssetMenu(fileName = "Passive prefab ability", menuName = "Abilities/Passive prefab", order = 4)]
    public class PassiveAbilityPrefabData : PassiveAbilityData, IPrefabData
    {

        #region Fields

        [SerializeField] private string _prefabDirectory;
        
        #endregion

        #region Properties

        public string PrefabDirectory => _prefabDirectory;
        
        #endregion

    }

}