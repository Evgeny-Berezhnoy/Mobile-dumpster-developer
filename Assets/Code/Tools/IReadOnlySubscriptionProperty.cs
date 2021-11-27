using System;

namespace Tools
{

    public interface IReadOnlySubscriptionProperty<T>
    {

        #region Properties
        
        T Value { get; }

        #endregion

        #region Methods

        void SubscribeOnChange(Action<T> subscriptionAction);
        void UnsubscribeOnChange(Action<T> unsubscriptionAction);
        void UnsubscribeAllOnChange();

        #endregion

    }

}