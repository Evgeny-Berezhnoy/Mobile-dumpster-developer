using System;
using UnityEngine;
using Abilities;

namespace UserInterface
{

    public class AbilityUIData : ISlidingSlotData, IButtonChainData
    {

        #region Fields

        private IAbility _ability;

        #endregion

        #region Properties

        public IAbility Ability => _ability;
        public EAbilityType Type => _ability.Model.Type;
        public Sprite Sprite => _ability.Model.Sprite;
        public EAbilityRecieverType RecieverType => _ability.RecieverType;
        public bool IsRevertable => _ability is IOverridableAbility;
        public Action ApplyAction { get; set; }
        public Action UnapplyAction { get; set; }
        
        #endregion

        #region Constructors

        public AbilityUIData(IAbility ability, Action applyAction, Action unapplyAction) : this(ability, applyAction)
        {

            UnapplyAction = unapplyAction;

        }

        public AbilityUIData(IAbility ability, Action applyAction) : this(ability)
        {

            ApplyAction = applyAction;

        }

        public AbilityUIData(IAbility ability)
        {

            _ability = ability;

        }

        #endregion

    }

}