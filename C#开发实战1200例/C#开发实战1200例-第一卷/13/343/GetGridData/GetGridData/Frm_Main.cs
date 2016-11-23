using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GetGridData
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //向DataGridView中添加数据
            this.dataGridView1.ColumnCount = 5;
            this.dataGridView1.Rows.Add(new string[] { "一", "二", "三", "四", "五" });
            this.dataGridView1.Rows.Add(new string[] { "六", "七", "八", "九", "十" });
            this.dataGridView1.Rows.Add(new string[] { "十一", "十二", "十三", "十四", "十五" });
            this.dataGridView1.Rows.Add(new string[] { "十六", "十七", "十八", "十九", "二十" });
            this.dataGridView1.Rows.Add(new string[] { "二十一", "二十二", "二十三", "二十四", "二十五" });
            this.dataGridView1.AutoResizeColumns();
            this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        }

        private string str = "";
        private bool Bool_Blank = false;//单元格是否为空
        private bool Bool_All = false;//是否全部替换

        private void button1_Click(object sender, EventArgs e)
        {
            str = CopyDataGridView(dataGridView1);
            AddDataGridView(dataGridView2, str, Bool_Blank, Bool_All);
        }

        /// <summary>
        /// 通过剪贴板复制DataGridView控件中所选中的内容.
        /// </summary>
        /// <param DGView="DataGridView">DataGridView类</param>
        /// <return>字符串</return>
        public string CopyDataGridView(DataGridView DGView)
        {
            string tem_str = "";
            if (DGView.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    //将数据添加到剪贴板中
                    Clipboard.SetDataObject(DGView.GetClipboardContent());
                    //从剪贴板中获取信息
                    tem_str = Clipboard.GetText();
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    return "";
                }
            }
            return tem_str;
        }

        /// <summary>
        /// 将字符串按指定的格式添加到DataGridView控件中（如果有被选中的单元格，则修改单元格中的内容）.
        /// </summary>
        /// <param DGView="DataGridView">DataGridView类</param>
        /// <param s="string">要替换的单元格字符串</param>
        /// <param Blank="bool">标识，如果是空格是否替换成空格</param>
        /// <param All="bool">标识，是否全部替换</param>
        public void AddDataGridView(DataGridView DGView, string s, bool Blank, bool All)
        {
            string tem_str = s;
            int tem_n = 0;
            int RowCount = 0;//行数
            int CellCount = 0;//列数
            bool tem_bool = true;
            string tem_s = "";
            if (s.IndexOf("\r\n") != -1)//如果替换的为多行
                while (tem_bool)//获取单元格的行数和列数
                {
                    tem_s = "";
                    if (tem_str.IndexOf("\r\n") != -1)//如果获取的不是最后一行
                    {
                        tem_s = tem_str.Substring(0, tem_str.IndexOf("\r\n") + 2);//获取当前行中的数据
                        //获取当前行中能被识别的数据
                        tem_str = tem_str.Substring(tem_str.IndexOf("\r\n") + 2, tem_str.Length - tem_str.IndexOf("\r\n") - 2);
                        tem_n = 1;
                        while (tem_s.IndexOf("\t") > -1)//遍历当前行中的空格
                        {
                            //去除已读取的空格
                            tem_s = tem_s.Substring(tem_s.IndexOf("\t") + 1, tem_s.Length - tem_s.IndexOf("\t") - 1);
                            tem_n += 1;//获取列数
                        }
                        if (tem_n > CellCount)//判断当前列数是否为最大列数
                            CellCount = tem_n;//获取最大的列数
                    }
                    else//如果读取的是最后一行
                    {
                        tem_n = 1;
                        while (tem_s.IndexOf("\t") > -1)
                        {
                            tem_s = tem_s.Substring(tem_s.IndexOf("\t") + 1, tem_s.Length - tem_s.IndexOf("\t") - 1);
                            tem_n += 1;
                        }
                        if (tem_n > CellCount)
                            CellCount = tem_n;
                        tem_bool = false;//遍历结束
                    }
                    ++RowCount;//读取行数
                }
            else//如果读取的为单行数据
            {
                tem_n = 1;
                tem_s = s;
                while (tem_s.IndexOf("\t") > -1)
                {
                    tem_s = tem_s.Substring(tem_s.IndexOf("\t") + 1, tem_s.Length - tem_s.IndexOf("\t") - 1);
                    tem_n += 1;
                }
                if (tem_n > CellCount)
                    CellCount = tem_n;
                ++RowCount;//读取行数
            }
            string[,] Strarr = new string[RowCount, CellCount];//定义一个数组，用于记录复制的单元格信息

            tem_str = s;
            tem_n = 0;
            //将单元格信息添加到数组中
            for (int i = 0; i < RowCount; i++)//遍历单元格的行
            {
                for (int j = 0; j < CellCount; j++)//遍历单元格的列
                {
                    tem_s = "";
                    if (tem_str.IndexOf("\r\n") != -1)//如果不是最后一行
                    {
                        if (tem_str.IndexOf("\t") <= -1)//设置读取数据的位置
                            tem_n = tem_str.IndexOf("\r");//最后一个数据的位置
                        else
                            tem_n = tem_str.IndexOf("\t");//不是最后一个数据的位置
                        tem_s = tem_str.Substring(0, tem_str.IndexOf("\r\n") + 2);//读取单元格数据
                    }
                    else//如果是最后一行
                    {
                        if (tem_str.IndexOf("\t") <= -1)//设置读取数据的位置
                            tem_n = tem_str.Length;//最后一个数据的位置
                        else
                            tem_n = tem_str.IndexOf("\t");//不是最后一个数据的位置
                        tem_s = tem_str;//读取单元格数据
                    }
                    if (tem_s.Length > 0)//如果当前行有数据
                    {
                        if (tem_s.Substring(0, 1) == "\t")//如果第一个字符为空
                            Strarr[i, j] = "";//向数组中添加一个空记录
                        else
                        {
                            Strarr[i, j] = tem_s.Substring(0, tem_n);//向数组中添加数据
                        }
                    }
                    else
                        Strarr[i, j] = "";//向数组中添加空记录
                    if (tem_s.Length > tem_n)//如果记录没有读取完
                        tem_str = tem_s.Substring(tem_n + 1, tem_s.Length - tem_n - 1);//获取没有读取的记录
                }
                if (s.IndexOf("\r\n") > -1)//如果不是最后一行数据
                {
                    s = s.Substring(s.IndexOf("\r\n") + 2, s.Length - s.IndexOf("\r\n") - 2);//读取下一行数据
                    tem_str = s;
                }
            }
            if (All)//如果要全部替换
                DGView.Rows.Clear();//清空DataGridView控件
            if (DGView.SelectedRows.Count == 0 && DGView.SelectedCells.Count == 0)//如果DataGridView中没有数据
            {
                DGView.ColumnCount = CellCount;//设置列数
                string[] stra = new string[CellCount];//定义一个一维数组
                //向DataGridView中添加行数据
                for (int i = 0; i < RowCount; i++)//读取行
                {
                    for (int j = 0; j < CellCount; j++)//读取列
                    {
                        if (Strarr[i, j] == "")//如果当前单元格为空
                        {
                            if (Blank)//如果用*号替换
                                stra[j] = "*";//在空单元格中添加*号
                            else
                                stra[j] = "";//以空格显示空单元格
                        }
                        else
                        {
                            stra[j] = Strarr[i, j];//记录当前行中的信息
                        }
                    }
                    DGView.Rows.Add(stra);//将行中的信息添加到DataGridView控件

                }
                DGView.AutoResizeColumns();//向DataGridView控件添加所有的单元格信息
                DGView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;//将所选择的单元格复制到剪贴板中
            }
            else//如果DataGridView中有数据
            {
                int maxrow = 0;//记录DataGridView控件中最小单元格的行数
                int maxcell = 0;//记录DataGridView控件中最小单元格的列数
                for (int i = 0; i < DGView.SelectedCells.Count; i++)//获取选中单元格中最大单元格的行数和列数
                {
                    if (DGView.SelectedCells[i].RowIndex > maxrow)//如果单元格的行数大于当前指定的行数
                        maxrow = DGView.SelectedCells[i].RowIndex;//记录当前单元格的行数
                    if (DGView.SelectedCells[i].ColumnIndex > maxcell)//如果单元格的列数大于当前指定的列数
                        maxcell = DGView.SelectedCells[i].ColumnIndex;//记录当前单元格的列数
                }
                int minrow = maxrow;//记录DataGridView控件中最大单元格的行数
                int mincell = maxcell;//记录DataGridView控件中最大单元格的列数
                for (int i = 0; i < DGView.SelectedCells.Count; i++)//获取选中单元格中最小单元格的行数和列数
                {
                    if (DGView.SelectedCells[i].RowIndex < minrow)//如果单元格的行数小于当前指定的行数
                        minrow = DGView.SelectedCells[i].RowIndex;//记录当前单元格的行数
                    if (DGView.SelectedCells[i].ColumnIndex < mincell)//如果单元格的列数小于当前指定的列数
                        mincell = DGView.SelectedCells[i].ColumnIndex;//记录当前单元格的列数
                }
                //向DataGridView控件中添加选中单元格中最小单元格与最大单元格中的所有单元格
                for (int i = 0; i < maxrow - (minrow - 1); i++)//遍历行数
                {
                    if (i >= RowCount)//如果超出要添加的行数
                        break;//退出循环
                    for (int j = 0; j < maxcell - (mincell - 1); j++)//遍历列数
                    {
                        if (j >= CellCount)//如果超出要添加的列数
                            break;//退出循环
                        if (Strarr[i, j]=="")//如果添加的单元格为空
                        {
                            if (Blank)//如果用*号替换空格
                                DGView.Rows[i + minrow].Cells[j + mincell].Value = "*";//用*号替换空单元格
                        }
                        else
                            DGView.Rows[i + minrow].Cells[j + mincell].Value = Strarr[i, j];//设置当前单元格的值
                    }
                }
            }

        }

        private void Tool_Blank_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)//如果该项被选中
            {
                ((ToolStripMenuItem)sender).Checked = false;//取消该项的选中状态
                Bool_Blank = false;//空单元格不用*号替换
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;//设置该项被选中
                Bool_Blank = true;//空单元格用*号替换
            }
        }

        private void Tool_All_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)//如果该项被选中
            {
                ((ToolStripMenuItem)sender).Checked = false;//取消该项的选中状态
                Bool_All = false;//全部替换
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;//设置该项被选中
                Bool_All = true;//替换选中的部份
            }
        }
    }
}
