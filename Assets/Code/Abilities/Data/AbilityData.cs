using UnityEngine;

namespace Abilities
{

    public abstract class AbilityData : ScriptableObject
    {

        #region Fields

        [SerializeField] protected string _title;
        [SerializeField] protected string _spriteDirectory;
        [SerializeField] protected int _id;
        [SerializeField] protected float _value;

        #endregion

        #region Properties

        public string Title => _title;
        public string SpriteDirectory => _spriteDirectory;
        public int ID => _id;
        public float Value => _value;
        public abstract EAbilityType Type { get; }

        #endregion

    }

}