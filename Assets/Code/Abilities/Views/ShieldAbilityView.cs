using UnityEngine;
using UnityEngine.UI;

namespace Abilities
{

    [RequireComponent(typeof(SpriteRenderer))]
    public class ShieldAbilityView : MonoBehaviour
    {

        #region Fields

        private SpriteRenderer _spriteRenderer;

        #endregion

        #region Properties

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        #endregion

    }

}