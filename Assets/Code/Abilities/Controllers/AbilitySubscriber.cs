using System.Collections.Generic;
using UserInterface;

namespace Abilities
{
    
    public class AbilityUISubscriber
    {

        #region Fields

        private List<AbilityUIData> _abilityUIDatas = new List<AbilityUIData>();
        private AbilityUIData _startPassiveAbilityData;
        private AbilityUIData _startActiveAbilityData;

        #endregion

        #region Properties

        public List<AbilityUIData> AbilityUIDatas => _abilityUIDatas;
        public AbilityUIData StartPassiveAbilityData => _startPassiveAbilityData;
        public AbilityUIData StartActiveAbilityData => _startActiveAbilityData;

        #endregion

        #region Constructors

        public AbilityUISubscriber(List<IAbility> abilities)
        {

            for(int i = 0; i < abilities.Count; i++)
            {

                var abilityUIData = new AbilityUIData(abilities[i]);

                _abilityUIDatas.Add(abilityUIData);

                if (_startPassiveAbilityData == null && abilityUIData.Type == EAbilityType.Passive) _startPassiveAbilityData    = abilityUIData;
                if (_startActiveAbilityData == null && abilityUIData.Type == EAbilityType.Active) _startActiveAbilityData       = abilityUIData;

            };
            
        }

        #endregion

        #region Methods

        public void SubscribeReceiver(EAbilityRecieverType type, IAbilityReceiver receiver)
        {

            for(int i = 0; i < _abilityUIDatas.Count; i++)
            {

                var abilityData = _abilityUIDatas[i];

                if (abilityData.RecieverType != type) continue;

                if (abilityData.IsRevertable)
                {

                    abilityData.UnapplyAction = () =>
                    {

                        ((IOverridableAbility)abilityData.Ability).Unapply(receiver);

                    };

                };

                abilityData.ApplyAction = () =>
                {

                    abilityData.Ability.Apply(receiver);

                };
                
            };

        }

        #endregion

    }

}