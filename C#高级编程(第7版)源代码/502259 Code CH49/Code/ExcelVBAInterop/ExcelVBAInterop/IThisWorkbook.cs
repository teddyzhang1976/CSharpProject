using System;
using System.Runtime.InteropServices;

namespace ExcelVBAInterop
{
    [ComVisible(true)]
    public interface IThisWorkbook
    {
        void NameSheet();
    }
}
