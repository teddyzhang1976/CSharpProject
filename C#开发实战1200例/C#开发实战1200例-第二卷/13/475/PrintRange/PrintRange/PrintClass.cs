using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using System.Data;
using System.Collections;

namespace PrintRange
{
    //=====================================================
    //Copyright (C) 2008-2009 小科
    //All rights reserved
    //CLR版本:            2.0.50727.1433
    //新建项输入的名称: PrintClass
    //机器名称:            MRWXK
    //命名空间名称:      PrintRange
    //文件名:              PrintClass
    //当前系统时间:      2008-12-04 15:56:01
    //当前登录用户名:   Administrator
    //创建年份:           2008
    //http://www.mingribook.com
    //======================================================
    class PrintClass
    {
        #region  全局变量
        private DataGridView datagrid;
        private PrintDocument printdocument;
        private PageSetupDialog pagesetupdialog;
        private PrintPreviewDialog printpreviewdialog;
        int currentpageindex = 0;//当前页的编号
        int rowcount = 0;//数据的行数
        int pagecount = 0;//打印页数
        public int x = 0;//绘画时的x轴位置
        public int PrintPageHeight = 1169;//打印的默认高度
        public int PrintPageWidth = 827;//打印的默认宽度
        public int headerheight = 30;//标题高度
        public int topmargin = 60; //顶边距 
        public int celltopmargin = 6;//单元格顶边距 
        public int pagerowcount = 7;//每页行数 
        public int rowgap = 23;//行高 
        public int colgap = 5;//每列间隔 
        public int leftmargin = 50;//左边距 
        public Font headerfont = new Font("arial", 9, FontStyle.Bold);//列名标题字体
        public Brush brushHeaderFont = new SolidBrush(Color.Black);//列名字体画刷
        public Font Cellfont = new Font("arial", 9);//单元格字体
        public bool isautopagerowcount = true;//是否自动计算行数
        public int buttommargin = 80;//底边距 
        public bool PageAspect = false;//打印的方向
        public static bool PageScape = false;//打印方向
        public int PageSheet = 0;
        #endregion

        #region  打印信息的初始化
        /// <summary>
        /// 打印信息的初始化
        /// </summary>
        /// <param datagrid="DataGridView">打印数据</param>
        /// <param PageS="int">纸张大小</param>
        /// <param lendscape="bool">是否横向打印</param>
        public PrintClass(DataGridView datagrid, int PageS, bool lendscape)
        {
            this.datagrid = datagrid;//获取打印数据
            this.PageSheet = PageS;//纸张大小
            printdocument = new PrintDocument();//实例化PrintDocument类
            pagesetupdialog = new PageSetupDialog();//实例化PageSetupDialog类
            pagesetupdialog.Document = printdocument;//获取当前页的设置
            printpreviewdialog = new PrintPreviewDialog();//实例化PrintPreviewDialog类
            printpreviewdialog.Document = printdocument;//获取预览文档的信息
            printpreviewdialog.FormBorderStyle = FormBorderStyle.Fixed3D;//设置窗体的边框样式
            //横向打印的设置
            if (PageSheet >= 0)
            {
                if (lendscape == true)
                {
                    printdocument.DefaultPageSettings.Landscape = lendscape;//横向打印
                }
                else
                {
                    printdocument.DefaultPageSettings.Landscape = lendscape;//纵向打印
                }
            }
            pagesetupdialog.Document = printdocument;
            printdocument.PrintPage += new PrintPageEventHandler(this.printdocument_printpage);//事件的重载
        }
        #endregion

        #region  纸张大小的设置
        /// <summary>
        ///  纸张大小的设置
        /// </summary>
        /// <param n="int">纸张大小的编号</param>
        /// <returns>返回string对象</returns>
        public string Page_Size(int n)
        {
            string pageN = "";//纸张的名称
            switch (n)
            {
                case 1: { pageN = "A5"; PrintPageWidth = 583; PrintPageHeight = 827; break; }
                case 2: { pageN = "A6"; PrintPageWidth = 413; PrintPageHeight = 583; break; }
                case 3: { pageN = "B5(ISO)"; PrintPageWidth = 693; PrintPageHeight = 984; break; }
                case 4: { pageN = "B5(JIS)"; PrintPageWidth = 717; PrintPageHeight = 1012; break; }
                case 5: { pageN = "Double Post Card"; PrintPageWidth = 583; PrintPageHeight = 787; break; }
                case 6: { pageN = "Envelope #10"; PrintPageWidth = 412; PrintPageHeight = 950; break; }
                case 7: { pageN = "Envelope B5"; PrintPageWidth = 693; PrintPageHeight = 984; break; }
                case 8: { pageN = "Envelope C5"; PrintPageWidth = 638; PrintPageHeight = 902; break; }
                case 9: { pageN = "Envelope DL"; PrintPageWidth = 433; PrintPageHeight = 866; break; }
                case 10: { pageN = "Envelope Monarch"; PrintPageWidth = 387; PrintPageHeight = 750; break; }
                case 11: { pageN = "ExeCutive"; PrintPageWidth = 725; PrintPageHeight = 1015; break; }
                case 12: { pageN = "Legal"; PrintPageWidth = 850; PrintPageHeight = 1400; break; }
                case 13: { pageN = "Letter"; PrintPageWidth = 850; PrintPageHeight = 1100; break; }
                case 14: { pageN = "Post Card"; PrintPageWidth = 394; PrintPageHeight = 583; break; }
                case 15: { pageN = "16K"; PrintPageWidth = 775; PrintPageHeight = 1075; break; }
                case 16: { pageN = "8.5x13"; PrintPageWidth = 850; PrintPageHeight = 1300; break; }
            }
            return pageN;//返回纸张的名
        }
        #endregion

        #region  页的打印事件
        /// <summary>
        ///  页的打印事件(主要用于绘制打印报表)
        /// </summary>
        private void printdocument_printpage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintPageWidth = e.PageBounds.Width;//获取打印线张的宽度
            PrintPageHeight = e.PageBounds.Height;//获取打印线张的高度
            if (this.isautopagerowcount)//自动计算页的行数
                pagerowcount = (int)((PrintPageHeight - this.topmargin - //获取每页的行数
                    this.headerfont.Height - this.headerheight -
                    this.buttommargin) / this.rowgap);
            pagecount = (int)(rowcount / pagerowcount);//获取打印多少页
            pagesetupdialog.AllowOrientation = true;//启动打印页面对话框的方向部分
            if (rowcount % pagerowcount > 0)//如果数据的行数大于页的行数
                pagecount++;//页数加1
            int colcount = 0;//记录数据的列数
            int y = topmargin;//获取表格的顶边距
            string cellvalue = "";//记录文本信息（单元格的文本信息）
            int startrow = currentpageindex * pagerowcount;//设置打印的初始页数
            int endrow = startrow + this.pagerowcount < rowcount ?//设置打印的最大页数
                startrow + pagerowcount : rowcount;
            int currentpagerowcount = endrow - startrow;//获取打印页数
            colcount = datagrid.ColumnCount;//获取打印数据的列数
            x = leftmargin;//获取表格的左边距
            //获取报表的宽度
            int cwidth = 0;
            for (int j = 0; j < colcount; j++)//循环数据的列数
            {
                if (datagrid.Columns[j].Width > 0)//如果列的宽大于０
                {
                    cwidth += datagrid.Columns[j].Width + colgap;//累加每列的宽度
                }
            }
            y += rowgap;//设置表格的上边线的位置
            //设置标题栏中的文字
            for (int j = 0; j < colcount; j++)//遍历列数据
            {
                int colwidth = datagrid.Columns[j].Width;//获取列的宽度
                if (colwidth > 0)//如果列的宽度大于0
                {
                    cellvalue = datagrid.Columns[j].HeaderText;//获取列标题
                    //绘制标题栏文字
                    e.Graphics.DrawString(cellvalue, headerfont,//绘制列标题
                        brushHeaderFont, x, y + celltopmargin);
                    x += colwidth + colgap;//横向，下一个单元格的位置
                    int nnp = y + currentpagerowcount * rowgap + this.headerheight;//下一行线的位置
                }
            }
            //打印所有的行信息
            for (int i = startrow; i < endrow; i++) //对行进行循环
            {
                x = leftmargin;//获取线的Ｘ坐标点
                for (int j = 0; j < colcount; j++)//对列进行循环
                {
                    if (datagrid.Columns[j].Width > 0)//如果列的宽度大于0
                    {
                        cellvalue = datagrid.Rows[i].Cells[j].Value.ToString();//获取单元格的值
                        e.Graphics.DrawString(cellvalue, Cellfont,//绘制单元格信息
                            brushHeaderFont, x, y + celltopmargin + rowgap);
                        x += datagrid.Columns[j].Width + colgap;//单元格信息的X坐标
                        y = y + rowgap * (cellvalue.Split(//单元格信息的Y坐标
                            new char[] { '\r', '\n' }).Length - 1);
                    }
                }
                y += rowgap;//设置下行的位置
            }
            currentpageindex++;//下一页的页码
            if (currentpageindex < pagecount)//如果当前页不是最后一页
            {
                e.HasMorePages = true;//打印副页
            }
            else
            {
                e.HasMorePages = false;//不打印副页
                this.currentpageindex = 0;//当前打印的页编号设为0
            }
        }
        #endregion

        #region 显示打印预览窗体
        /// <summary>
        ///  显示打印预览窗体
        /// </summary>
        public void print()
        {
            rowcount = 0;//记录数据的行数
            string paperName = Page_Size(PageSheet);//获取当前纸张的大小
            PageSettings storePageSetting = new PageSettings();//实列化一个对PageSettings对象
            foreach (PaperSize ps in printdocument.PrinterSettings.PaperSizes)//查找当前设置纸张
                if (paperName == ps.PaperName)//如果找到当前纸张的名称
                {
                    storePageSetting.PaperSize = ps;//获取当前纸张的信息
                }
            if (datagrid.DataSource.GetType().ToString() == "System.Data.DataTable")//判断数据类型
            {
                rowcount = ((DataTable)datagrid.DataSource).Rows.Count;//获取数据的行数
            }
            else if (datagrid.DataSource.GetType().ToString() == "System.Collections.ArrayList")//判断数据类型
            {
                rowcount = ((ArrayList)datagrid.DataSource).Count;//获取数据的行数
            }
            try
            {
                printdocument.DefaultPageSettings.Landscape = PageScape;//设置横向打印
                pagesetupdialog.Document = printdocument;
                printpreviewdialog.ShowDialog();//显示打印预览窗体
            }
            catch (Exception e)
            {
                throw new Exception("printer error." + e.Message);
            }
        }
        #endregion
    }
}