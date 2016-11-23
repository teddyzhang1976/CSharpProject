using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortFolio.View.AccountManager
{
    public partial class MoveInOutMoneyDlg : Form
    {
       private PortfolioMainDlg portFolioMDlg;

        //private static AccountEditDlg instance;
        private MoveInOutMoneyDlg()
        {
            InitializeComponent();
           // this.ControlBox = false; 
        }

        public MoveInOutMoneyDlg(PortfolioMainDlg pfMDlg)
            : this()
        {
            portFolioMDlg = pfMDlg;
        }
    }
}
