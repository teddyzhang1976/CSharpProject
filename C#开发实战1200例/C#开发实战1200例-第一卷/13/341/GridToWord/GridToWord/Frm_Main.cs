using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;

namespace GridToWord
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

        private Word.Application G_wa;//定义Word应用程序字段
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
            P_SaveFileDialog.Filter = "*.doc|*.doc";
            if (DialogResult.OK ==//确认是否保存文件
                P_SaveFileDialog.ShowDialog())
            {
                ThreadPool.QueueUserWorkItem(//开始线程池
                (pp) =>//使用lambda表达式
                {
                    G_wa = new Microsoft.Office.Interop.Word.Application();//创建应用程序对象
                    object P_obj = "Normal.dot";//定义文档模板
                    Word.Document P_wd = G_wa.Documents.Add(//向Word应用程序中添加文档
                        ref P_obj, ref G_missing, ref G_missing, ref G_missing);
                    Word.Range P_Range = P_wd.Range(//得到文档范围
                        ref G_missing, ref G_missing);
                    object o1 = Word.WdDefaultTableBehavior.//设置文档中表格格式
                        wdWord8TableBehavior;
                    object o2 = Word.WdAutoFitBehavior.//设置文档中表格格式
                        wdAutoFitWindow;
                    Word.Table P_WordTable = P_Range.Tables.Add(P_Range,//在文档中添加表格
                        P_Fruit.Count ,2, ref o1, ref o2);
                    P_WordTable.Cell(1, 1).Range.Text = "水果";//向表格中添加信息
                    P_WordTable.Cell(1, 2).Range.Text = "价格";//向表格中添加信息
                    for (int i = 2; i < P_Fruit.Count + 1; i++)
                    {
                        P_WordTable.Cell(i, 1).Range.Text =//向表格中添加信息
                            P_Fruit[i - 2].Name;
                        P_WordTable.Cell(i, 2).Range.Text =//向表格中添加信息
                            P_Fruit[i - 2].Price.ToString();
                    }
                    object P_Path = P_SaveFileDialog.FileName;
                    P_wd.SaveAs(//保存Word文件
                        ref P_Path,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                        ref G_missing, ref G_missing, ref G_missing);
                    ((Word._Application)G_wa.Application).Quit(//退出应用程序
                        ref G_missing, ref G_missing, ref G_missing);
                    this.Invoke(//调用窗体线程
                        (MethodInvoker)(() =>//使用lambda表达式
                        {
                            MessageBox.Show(//弹出消息对话框
                                "成功创建Word文档！", "提示！");
                        }));
                });
            }
        }
    }
}
