using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;

namespace GridToExcel
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dgv_Message.DataSource = new List<Fruit>() {//绑定数据集合
            new Fruit(){Name="苹果",Price=30},
            new Fruit(){Name="橘子",Price=40},
            new Fruit(){Name="鸭梨",Price=33},
            new Fruit(){Name="水蜜桃",Price=31}};
            dgv_Message.Columns[0].Width = 200;//设置列宽度
            dgv_Message.Columns[1].Width = 170;//设置列宽度
        }


        private Excel.Application G_ea;//定义Word应用程序字段
        private object G_missing = //定义G_missing字段并添加引用
            System.Reflection.Missing.Value;

        private void btn_OutPut_Click(object sender, EventArgs e)
        {
            List<Fruit> P_Fruit = new List<Fruit>();//创建数据集合
            foreach (DataGridViewRow dgvr in dgv_Message.Rows)
            {
                P_Fruit.Add(new Fruit()//向数据集合添加数据
                {
                    Name = dgvr.Cells[0].Value.ToString(),
                    Price = Convert.ToSingle(dgvr.Cells[1].Value.ToString())
                });
            }
            SaveFileDialog P_SaveFileDialog =//创建保存文件对话框对象
                new SaveFileDialog();
            P_SaveFileDialog.Filter = "*.xls|*.xls";
            if (DialogResult.OK ==//确认是否保存文件
                P_SaveFileDialog.ShowDialog())
            {
                ThreadPool.QueueUserWorkItem(//开始线程池
                (pp) =>//使用lambda表达式
                {
                    G_ea = new Microsoft.Office.Interop.Excel.Application();//创建应用程序对象
                    Excel.Workbook P_wk = G_ea.Workbooks.Add(G_missing);//创建Excel文档
                    Excel.Worksheet P_ws = (Excel.Worksheet)P_wk.Worksheets.Add(//创建工作区域
                        G_missing, G_missing, G_missing, G_missing);
                    for (int i = 0; i < P_Fruit.Count; i++)
                    {
                        P_ws.Cells[i + 1, 1] = P_Fruit[i].Name;//向Excel文档中写入内容
                        P_ws.Cells[i + 1, 2] = P_Fruit[i].//向Excel文档中写入内容
                            Price.ToString();
                    }
                    P_wk.SaveAs(//保存Word文件
                        P_SaveFileDialog.FileName, G_missing, G_missing, G_missing,
                        G_missing, G_missing, Excel.XlSaveAsAccessMode.xlShared, G_missing,
                        G_missing, G_missing, G_missing, G_missing);
                    ((Excel._Application)G_ea.Application).Quit();//退出应用程序
                        
                    this.Invoke(//调用窗体线程
                        (MethodInvoker)(() =>//使用lambda表达式
                        {
                            MessageBox.Show(//弹出消息对话框
                                "成功创建Excel文档！", "提示！");
                        }));
                });
            }
        }
    }
}
