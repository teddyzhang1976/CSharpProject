using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class Resource : IDisposable
    {
        #region IDisposable Members

        public void Dispose()
        {
            // release resource
        }

        #endregion
    }
}
