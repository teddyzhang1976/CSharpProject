using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;

namespace InsertControl
{
    public partial class ThisDocument
    {
        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            Word.Range P_Range1 = this.Paragraphs[1].Range;//得到文档范围
            Microsoft.Office.Tools.Word.Controls.Button P_btn =//向文档中添加按钮
                this.Controls.AddButton(P_Range1, 50, 20, "button1");
            P_btn.Text = "Button按钮";//设置按钮文本
            P_btn.Height = 50;//设置按钮高度
            P_btn.Width = 100;//设置按钮宽度
            P_btn.Click += new EventHandler(P_btn_Click);//添加单击事件
        }

        void P_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("感谢您对明日图书的支持！","提示！");//弹出消息对话框
        }

        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO 设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(ThisDocument_Shutdown);
        }

        #endregion
    }
}
