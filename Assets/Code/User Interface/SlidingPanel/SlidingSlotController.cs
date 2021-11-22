using System;
using UnityEngine;
using Interfaces;

namespace UserInterface
{

    public abstract class SlidingSlotController<T1, T2> : IDisposableAdvanced
        where T1 : MonoBehaviour
        where T2 : ISlidingSlotData
    {

        #region Interfaces Properties

        public bool IsDisposed { get; private set; }

        #endregion

        #region Constructors

        public SlidingSlotController(T1 slotView, T2 slotData) { }
        public SlidingSlotController(T1 slotView){}

        #endregion

        #region Destructors

        ~SlidingSlotController()
        {

            Dispose();

        }

        #endregion

        #region Interfaces Methods

        public virtual void Dispose()
        {

            if (IsDisposed)
            {

                return;

            }

            IsDisposed = true;

            GC.SuppressFinalize(this);

        }

        #endregion

        #region Methods

        public abstract void SetSlotData(T2 slotData);
        public abstract void SetSlotData();
        
        #endregion

    }

}