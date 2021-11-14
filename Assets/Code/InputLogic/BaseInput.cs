using System;
using System.Linq;
using UnityEngine;
using Interfaces;
using MVC;

using static Constants.Delegates;

namespace InputLogic
{

    public abstract class BaseInput : IController, IUpdate, IDisposableAdvanced
    {
        
        #region Events

        protected event AxisShiftDelegate _onAxisShift;

        #endregion

        #region Interfaces properties

        public bool IsDisposed { get; private set; }

        #endregion

        #region Interfaces Methods

        public abstract void OnUpdate(float deltaTime);

        public virtual void Dispose()
        {

            if (IsDisposed)
            {

                return;

            };

            IsDisposed = true;

            RemoveAllAxisShiftHandlers();

            GC.SuppressFinalize(this);

        }

        #endregion

        #region Methods

        public void OnAxisShift(Vector3 axisShift, float deltaTime)
        {

            _onAxisShift?.Invoke(axisShift, deltaTime);

        }

        public void AddAxisShiftHandler(AxisShiftDelegate handler)
        {

            _onAxisShift += handler;

        }

        public void RemoveAxisShiftHandler(AxisShiftDelegate handler)
        {

            _onAxisShift -= handler;

        }

        public void RemoveAllAxisShiftHandlers()
        {

            var axisShiftHandlers =
                _onAxisShift
                    ?.GetInvocationList()
                    .ToList()
                    .Cast<AxisShiftDelegate>()
                    .ToList();

            if(axisShiftHandlers == null)
            {

                return;

            };

            for (int i = 0; i < axisShiftHandlers.Count; i++)
            {

                _onAxisShift -= axisShiftHandlers[i];

            };

        }

        #endregion

    }

}