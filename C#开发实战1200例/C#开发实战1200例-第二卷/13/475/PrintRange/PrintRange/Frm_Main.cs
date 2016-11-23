using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PrintRange
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public bool Aspect = true;//打印方向
        public bool boundary = false;//是否打印分割线

        private void Form1_Activated(object sender, EventArgs e)
        {
            Graphics g = panel_Line.CreateGraphics();//在窗体中绘制一个预览表格
            int paneW = panel_Line.Width;//设置表格的宽度
            int paneH = panel_Line.Height;//设置表格的高度
            g.DrawRectangle(new Pen(Color.WhiteSmoke, paneW), 0, 0, paneW, paneH);//绘制一个矩形
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox_PageSize.SelectedIndex = 0;//设置选项的索引
            SqlConnection sqlcon = new SqlConnection(//创建数据库连接对象
@"Data Source=(local)\EXPRESS;Database=db_TomeTwo;UID=sa;Pwd=hbyt2008!@#;");
            SqlDataAdapter sqlda = new SqlDataAdapter(//创建适配器对象
                "select * from tb_Employee", sqlcon);
            DataSet myds = new DataSet();//创建数据集
            sqlda.Fill(myds);//填充数据集
            dataGridView1.DataSource = myds.Tables[0];//设置数据源
        }

        private void checkBox_Aspect_MouseDown(object sender, MouseEventArgs e)
        {
            //改变窗体中预览表格的方向
            int aspX = 0;//宽度
            int aspY = 0;//高度
            if (((CheckBox)sender).Checked == false)//如果不是纵向打印
            {
                aspX = 136;//设置大小
                aspY = 98;
                PrintClass.PageScape = true;//横向打印
            }
            else
            {
                aspX = 100;//设置大小
                aspY = 116;
                PrintClass.PageScape = false;//纵向打印
            }
            panel_Line.Width = aspX;//设置控件的宽度
            panel_Line.Height = aspY;//设置控件的高度
            aspX = (int)((groupBox1.Width - aspX) / 2);//设置控件的Top
            panel_Line.Location = new Point(aspX, 90);//设置控件的位置
            Form1_Activated(sender, e);//调用Activated事件
        }

        private void button_Preview_Click(object sender, EventArgs e)
        {
            PrintClass dgp = new PrintClass(//对打印信息进行设置
                this.dataGridView1, comboBox_PageSize.SelectedIndex, checkBox_Aspect.Checked);
            MSetUp(dgp);//记录窗体中打印信息的相关设置
            string[] header = new string[dataGridView1.ColumnCount];//创建一个与数据列相等的字符串数组
            for (int p = 0; p < dataGridView1.ColumnCount; p++)//记录所有列标题的名列
            {
                header[p] = dataGridView1.Columns[p].HeaderCell.Value.ToString();
            }
            dgp.print();//显示打印预览窗体
        }

        #region  设置打印数据的相关信息
        /// <summary>
        /// 设置打印数据的相关信息
        /// </summary>
        /// <param dgp="PrintClass">公共类PrintClass</param>
        private void MSetUp(PrintClass dgp)
        {
            dgp.PageAspect = Aspect;//设置横向打印
        }
        #endregion
    }
}
