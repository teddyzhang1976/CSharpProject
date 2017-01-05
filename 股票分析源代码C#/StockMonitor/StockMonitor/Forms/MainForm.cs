using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ImageOfStock;
namespace StockMonitor.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

          string codepath = AppDomain.CurrentDomain.BaseDirectory + @"history\SZNSE\day\000012.day";
            //string codepath = AppDomain.CurrentDomain.BaseDirectory + @"history\SZNSE\day\000686.day";
          this.panel1.Controls.Clear();
          TestDayLineStockForm TDLSF = new TestDayLineStockForm(codepath);
         // TDLSF.Show();
          TDLSF.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panel1.Controls.Add(TDLSF);
        //  string codepath = AppDomain.CurrentDomain.BaseDirectory + @"history\SZNSE\day\000686.day";
          //TestTimeLineStockForm TDLSF = new TestTimeLineStockForm();
          //TDLSF.Show();

            

         //  List<StockMonitor.DayLineReader.StockWeightInfo> LS=StockMonitor.DayLineReader.WGTReader.ReadStockWeights(AppDomain.CurrentDomain.BaseDirectory + @"history/SHASE/weight/600030.wgt");
          
        
        }
    }
}