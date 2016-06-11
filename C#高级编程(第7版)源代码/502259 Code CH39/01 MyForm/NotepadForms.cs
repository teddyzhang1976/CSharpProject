using System;
using System.Windows.Forms;
namespace NotepadForms
{
    public class MyForm : System.Windows.Forms.Form
    {
        public MyForm()
        {
        }
        [STAThread]
        static void Main()
        {
            Application.Run(new MyForm());
        }
    }
}
