using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PortFolio.Control;

namespace PortFolio
{

    class Starter
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //loadin data
            PortFolioManager pfMgr = PortFolioManager.singleInstance;
            //Application.Run(new PortfolioMainDlg());
            //Application.Run(new PositionTradingDlg());
            Application.Run(pfMgr.selectMainDlg());
        }
    }
}
