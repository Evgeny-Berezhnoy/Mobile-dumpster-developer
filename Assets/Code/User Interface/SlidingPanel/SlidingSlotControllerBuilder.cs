using UnityEngine;

namespace UserInterface
{
    public abstract class SlidingSlotControllerBuilder<T1, T2>
        where T1 : MonoBehaviour
        where T2 : ISlidingSlotData
    {

        #region Methods

        public abstract SlidingSlotController<T1, T2> Construct(T1 view, T2 data);
        public abstract SlidingSlotController<T1, T2> Construct(T1 view);
        
        #endregion

    }

}