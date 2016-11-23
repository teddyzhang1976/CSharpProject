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
    public partial class GeneralJournalDlg : Form
    {
        private PortfolioMainDlg portFolioMDlg;
        private GeneralJournalDlg()
        {
            InitializeComponent();
        }
        public GeneralJournalDlg(PortfolioMainDlg pfMDlg)
            : this()
        {
            portFolioMDlg = pfMDlg;
        }
    }
}
