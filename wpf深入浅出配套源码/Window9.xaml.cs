using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Window9.xaml 的交互逻辑
    /// </summary>
    public partial class Window9 : Window
    {
        public Window9()
        {
            InitializeComponent();
            DataTable dtInfo = CreateDataTable();
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dtInfo.NewRow();
                dr[0] = i;
                dr[1] = "猴王" + i;
                dr[2] = i + 10;
                dr[3] = "男";
                dtInfo.Rows.Add(dr);
            }

            this.listView1.DataContext = dtInfo;
            this.listView1.SetBinding(ListView.ItemsSourceProperty, new Binding());
        }


        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable("newtable");
            
            DataColumn[] columns = new DataColumn[]{new DataColumn("Id"),new DataColumn("Name"),new DataColumn("Age"),new DataColumn("Sex")};
            dt.Columns.AddRange(columns);
            return dt;
        }
    }
}
