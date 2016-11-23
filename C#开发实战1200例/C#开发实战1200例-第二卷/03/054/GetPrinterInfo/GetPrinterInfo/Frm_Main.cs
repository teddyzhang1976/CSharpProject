using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetPrinterInfo
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Clear();//清空信息
            try
            {
                //遍历所有打印机信息
                foreach (string mPrinterName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    textBox1.Text = mPrinterName;//显示打印机名称
                    //实例化PrinterSettings对象
                    System.Drawing.Printing.PrinterSettings mprinter = new System.Drawing.Printing.PrinterSettings();
                    mprinter.PrinterName = mPrinterName;//设置要使用的打印机名称
                    if (mprinter.IsValid)//判断是否指定了有效的打印机
                    {
                        //遍历分辨率信息
                        foreach (System.Drawing.Printing.PrinterResolution resolution in mprinter.PrinterResolutions)
                        {
                            comboBox1.Items.Add(resolution.ToString());//将分辨率信息添加到下拉列表中
                        }
                        string prinsize = "";//声明变量存储打印尺寸信息
                        //遍历所有的打印尺寸信息
                        foreach (System.Drawing.Printing.PaperSize size in mprinter.PaperSizes)
                        {
                            if (Enum.IsDefined(size.Kind.GetType(), size.Kind))
                                prinsize += size.ToString() + "\n";//获取所有的打印尺寸信息
                        }
                        richTextBox1.AppendText(prinsize + "\n");//显示打印尺寸信息
                    }
                }
            }
            catch { }
        }
    }
}
