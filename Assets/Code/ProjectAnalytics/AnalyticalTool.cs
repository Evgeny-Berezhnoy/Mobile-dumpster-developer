using System.Collections.Generic;
using UnityEngine.Analytics;

namespace ProjectAnalytics
{
    public class AnalyticalTool : IAnalyticalTool
    {

        #region Interface Methods

        public void InvokeAnalyticalEvent(string eventName)
        {

            var x = Analytics.CustomEvent(eventName);

        }

        public void InvokeAnalyticalEvent(string eventName, string key, object value)
        {

            var eventData = new Dictionary<string, object>()
            {
                
                [key] = value
            
            };

            InvokeAnalyticalEvent(eventName, eventData);

        }

        public void InvokeAnalyticalEvent(string eventName, Dictionary<string, object> eventData)
        {

            var x = Analytics.CustomEvent(eventName, eventData);

        }

        #endregion

    }

}