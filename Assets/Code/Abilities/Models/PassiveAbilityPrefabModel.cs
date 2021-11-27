using UnityEngine;
using Models;

namespace Abilities
{

    public class PassiveAbilityPrefabModel : PassiveAbilityModel
    {

        #region Fields

        private GameObject _prefab;

        #endregion

        #region Properties

        public GameObject Prefab => _prefab;

        #endregion

        #region Constructors

        public PassiveAbilityPrefabModel(PassiveAbilityPrefabData abilityData) : base(abilityData)
        {

            _prefab = ResourceLoader.LoadObject<GameObject>(abilityData.PrefabDirectory);

        }

        #endregion

    }

}