using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelVBAInterop
{
   public partial class NamingDialog : Form
   {
      public NamingDialog()
      {
         InitializeComponent();
      }

      public string SheetName
      {
         get
         {
            if (includeDatePrefixBox.Checked)
            {
               return string.Format("{0} {1}", DateTime.Now.ToString("yyyy-MM-dd"), sheetNameBox.Text);
            }
            else
            {
               return sheetNameBox.Text;
            }
         }
      }

      private void okButton_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void cancelButton_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }
   }
}
