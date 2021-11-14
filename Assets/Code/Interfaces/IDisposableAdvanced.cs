using System;

namespace Interfaces
{

    public interface IDisposableAdvanced : IDisposable
    {

        #region Properties

        bool IsDisposed { get; }

        #endregion

    }

}