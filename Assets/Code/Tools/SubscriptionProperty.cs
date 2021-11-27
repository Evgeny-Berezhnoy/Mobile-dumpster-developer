using System;
using System.Linq;
using Interfaces;

namespace Tools
{

    public class SubscriptionProperty<T> : IReadOnlySubscriptionProperty<T>, IDisposableAdvanced
    {

        #region Fields

        private T _value;
        private Action<T> _onChangeValue;

        #endregion

        #region Interfaces Properties

        public T Value
        {

            get => _value;
            set
            {

                _value = value;
                _onChangeValue?.Invoke(_value);

            }

        }

        public bool IsDisposed { get; private set; }

        #endregion

        #region Destructors

        ~SubscriptionProperty()
        {

            Dispose();

        }

        #endregion

        #region Interfaces Methods

        public void SubscribeOnChange(Action<T> subscriptionAction)
        {

            _onChangeValue += subscriptionAction;
        
        }

        public void UnsubscribeOnChange(Action<T> unsubscriptionAction)
        {

            _onChangeValue -= unsubscriptionAction;
        
        }

        public void UnsubscribeAllOnChange()
        {

            var subscribtions =
                _onChangeValue
                    ?.GetInvocationList()
                    .ToList()
                    .Cast<Action<T>>()
                    .ToList();

            if (subscribtions == null)
            {

                return;

            };

            for (int i = 0; i < subscribtions.Count; i++)
            {

                _onChangeValue -= subscribtions[i];

            };

        }

        public void Dispose()
        {

            if (IsDisposed)
            {

                return;

            };

            IsDisposed = true;

            UnsubscribeAllOnChange();

            GC.SuppressFinalize(this);

        }
        
        #endregion

    }

}