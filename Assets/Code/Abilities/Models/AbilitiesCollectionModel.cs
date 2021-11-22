using System;
using System.Collections.Generic;

namespace Abilities
{

    public class AbilitiesCollectionModel
    {

        #region Fields

        public readonly List<AbilityModel> Models;

        #endregion

        #region Constructors

        public AbilitiesCollectionModel(AbilitiesCollectionData data)
        {

            Models = new List<AbilityModel>();

            for(int i = 0; i < data.Abilities.Count; i++)
            {

                Models.Add(CreateAbilityModel(data.Abilities[i]));

            };

        }

        #endregion

        #region Methods

        private AbilityModel CreateAbilityModel(AbilityData abilityData)
        {

            if(abilityData is ActiveAbilityPrefabData activeAbilityPrefabData)
            {

                return new ActiveAbilityPrefabModel(activeAbilityPrefabData);

            }
            else if (abilityData is ActiveAbilityData activeAbilityData)
            {

                return new ActiveAbilityModel(activeAbilityData);
                
            }
            else if (abilityData is PassiveAbilityPrefabData passiveAbilityPrefabData)
            {

                return new PassiveAbilityPrefabModel(passiveAbilityPrefabData);

            }
            else if (abilityData is PassiveAbilityData passiveAbilityData)
            {

                return new PassiveAbilityModel(passiveAbilityData);

            }
            else
            {

                throw new Exception("Ability data hasn't been identified.");

            };

        }

        #endregion

    }

}