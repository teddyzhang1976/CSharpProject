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
    public partial class PositionTradeDlg : Form
    {
        private PortfolioMainDlg portFolioMDlg;

        //private static AccountEditDlg instance;
        private PositionTradeDlg()
        {
            InitializeComponent();
           // this.ControlBox = false; 
        }

        public PositionTradeDlg(PortfolioMainDlg pfMDlg)
            : this()
        {
            portFolioMDlg = pfMDlg;
        }
    }
}
