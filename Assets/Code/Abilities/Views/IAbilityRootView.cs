using UnityEngine;

namespace Abilities
{

    interface IAbilityRootView : IAbilityReceiver
    {

        #region Properties

        Transform AbilityTransform { get; }

        #endregion

    }

}