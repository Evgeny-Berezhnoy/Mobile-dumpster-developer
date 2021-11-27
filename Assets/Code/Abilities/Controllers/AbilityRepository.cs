using System;
using System.Collections.Generic;

namespace Abilities
{

    public class AbilityRepository
    {

        #region Constants

        private const string _abilityCreationError = "Couldn't produce ability. Unexpected parameters set has been transfered.";

        #endregion

        #region Fields

        private List<IAbility> _abilities = new List<IAbility>();

        #endregion

        #region Properties

        public List<IAbility> Abilities => _abilities;

        #endregion

        #region Constructors

        public AbilityRepository(List<AbilityModel> abilityModels)
        {

            for(int i = 0; i < abilityModels.Count; i++)
            {

                _abilities.Add(CreateAbility(abilityModels[i]));

            };

        }

        #endregion

        #region Methods

        private IAbility CreateAbility(AbilityModel abilityModel)
        {
            
            if (abilityModel is ActiveAbilityModel activeAbilityModel)
            {

                if (activeAbilityModel is ActiveAbilityPrefabModel activeAbilityPrefabModel)
                {

                    if (activeAbilityModel.Effect == EActiveAbilityEffect.Shield)
                    {

                        return new ShieldAbilityController(activeAbilityPrefabModel);

                    };

                }
                else
                {

                    if (activeAbilityModel.Effect == EActiveAbilityEffect.Jump)
                    {

                        return new JumpAbilityController(activeAbilityModel);

                    };

                };

            }
            else if(abilityModel is PassiveAbilityModel passiveAbilityModel)
            {

                if(passiveAbilityModel.Effect == EPassiveAbilityEffect.Speed)
                {

                    return new SpeedAbilityController(passiveAbilityModel);

                };

            };

            throw new Exception(_abilityCreationError);

        }

        #endregion

    }

}