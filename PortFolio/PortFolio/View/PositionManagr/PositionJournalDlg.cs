using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortFolio.View.PositionManagr
{
    public partial class PositionJournalDlg : Form
    {
        private PortfolioMainDlg portFolioMDlg;
        private PositionJournalDlg()
        {
            InitializeComponent();
        }
        public PositionJournalDlg(PortfolioMainDlg pfMDlg)
            : this()
        {
            portFolioMDlg = pfMDlg;
        }
    }
}
