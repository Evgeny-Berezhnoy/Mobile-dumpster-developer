using UnityEngine;
using Models;

namespace Abilities
{

    public abstract class AbilityModel
    {

        #region Fields

        protected string _title;
        protected Sprite _sprite;
        protected int _id;
        protected float _value;
        protected EAbilityType _type;

        #endregion

        #region Properties

        public string Title => _title;
        public Sprite Sprite => _sprite;
        public int ID => _id;
        public float Value => _value;
        public EAbilityType Type => _type;

        #endregion

        #region Constructors

        public AbilityModel(AbilityData abilityData)
        {

            _title  = abilityData.Title;
            _sprite = ResourceLoader.LoadObject<Sprite>(abilityData.SpriteDirectory);
            _id     = abilityData.ID;
            _value  = abilityData.Value;
            _type   = abilityData.Type;

        }

        #endregion

    }

}