using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PortFolio.Control;

namespace PortFolio
{
    public partial class PositionMonitorDlg : Form
    {
        PortFolioManager portFolioManager;
        public PositionMonitorDlg()
        {
            Console.WriteLine("PositionTradingDlg without par");
            InitializeComponent();
        }

        public PositionMonitorDlg(PortFolioManager portFolioManager):this()
        {
            Console.WriteLine("PositionTradingDlg with par");
            this.portFolioManager = portFolioManager;
        }
    }
}
