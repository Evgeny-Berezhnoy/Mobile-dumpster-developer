using UnityEngine;
using Interfaces;

namespace Abilities
{

    [CreateAssetMenu(fileName = "Active prefab ability", menuName = "Abilities/Active prefab", order = 2)]
    public class ActiveAbilityPrefabData : ActiveAbilityData, IPrefabData
    {

        #region Fields

        [SerializeField] private string _prefabDirectory;

        #endregion

        #region Properties

        public string PrefabDirectory => _prefabDirectory;

        #endregion

    }

}