using UnityEngine;
using Models;

namespace Abilities
{

    public class ActiveAbilityPrefabModel : ActiveAbilityModel
    {

        #region Fields

        private GameObject _prefab;

        #endregion

        #region Properties

        public GameObject Prefab => _prefab;

        #endregion

        #region Constructors

        public ActiveAbilityPrefabModel(ActiveAbilityPrefabData abilityData) : base(abilityData)
        {

            _prefab = ResourceLoader.LoadObject<GameObject>(abilityData.PrefabDirectory);

        }

        #endregion

    }

}