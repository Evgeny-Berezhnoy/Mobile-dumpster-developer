using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAnalytics
{

    public interface IAnalyticalTool
    {

        #region Methods

        void InvokeAnalyticalEvent(string eventName);
        void InvokeAnalyticalEvent(string eventName, string key, object value);

        #endregion

    }

}
