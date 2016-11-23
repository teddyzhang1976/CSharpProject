using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PortFolio.View;

namespace PortFolio.View.AccountManager
{
    public partial class UpdateAccountNameDlg : Form
    {
        private PortfolioMainDlg portFolioMDlg;
        private UpdateAccountNameDlg()
        {
            InitializeComponent();
        }
        public UpdateAccountNameDlg(PortfolioMainDlg pfMDlg)
            : this()
        {
            portFolioMDlg = pfMDlg;
        }
    }
}
