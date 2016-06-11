using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Office.Tools.Excel;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using System.Runtime.InteropServices;

namespace ExcelVBAInterop
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public partial class ThisWorkbook : ExcelVBAInterop.IThisWorkbook
    {
        private void ThisWorkbook_Startup(object sender, System.EventArgs e)
        {
        }

        private void ThisWorkbook_Shutdown(object sender, System.EventArgs e)
        {
        }

        public void NameSheet()
        {
            NamingDialog dlg = new NamingDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ((Excel.Worksheet)this.ActiveSheet).Name = dlg.SheetName;
            }
        }

        protected override object GetAutomationObject()
        {
            return this;
        }


        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisWorkbook_Startup);
            this.Shutdown += new System.EventHandler(ThisWorkbook_Shutdown);
        }

        #endregion

    }
}
