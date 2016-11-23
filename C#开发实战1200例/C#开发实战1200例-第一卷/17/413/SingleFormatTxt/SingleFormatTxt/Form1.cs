using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;

namespace SingleFormatTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Computer MyComputer = new Computer();
            txtResult.Text = MyComputer.FileSystem.ReadAllText("test.txt");
        }

        private void btnParseTextFiles_Click(object sender, EventArgs e)
        {
            using (TextFieldParser myReader = new TextFieldParser("test.txt"))
            {
                // 表示档案内容是字符分隔。
                myReader.TextFieldType = FieldType.Delimited;
                // 定义文本文件的字符分隔符。
                myReader.Delimiters = new String[] { "," };
                this.DataGridView1.Rows.Clear();
                DataGridView1.ColumnHeadersVisible = true;
                // 设定栏标题样式。
                DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
                columnHeaderStyle.BackColor = Color.Beige;
                columnHeaderStyle.Font = new Font("Verdana", 9, FontStyle.Bold);
                DataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                string[] currentRow;
                int myRowCount = 1;
                int myColCount = 0;
                // 循环处理文本文件中所有数据列的所有字段。
                while (!myReader.EndOfData)
                {
                    try
                    {
                        currentRow = myReader.ReadFields();
                        if (myRowCount == 1)
                        {
                            foreach (string currentField in currentRow)
                            {
                                // 动态设定 DataGridView 控件的字段数目。
                                DataGridView1.ColumnCount = myColCount + 1;
                                // 设定 DataGridView 控件各栏的标题名称。
                                DataGridView1.Columns[myColCount].Name = currentField;
                                myColCount += 1;
                            }
                        }
                        else
                        {
                            this.DataGridView1.Rows.Add(currentRow);
                        }
                    }
                    catch (MalformedLineException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    myRowCount += 1;
                }
            }
        }
    }
}
