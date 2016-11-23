using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;

namespace ApplicationInWord
{
    public partial class ThisDocument
    {
        #region 私有字段
        private object G_Missing = System.Reflection.Missing.Value;//创建Missing对象
        private List<Student> G_List_Student = new List<Student>();//创建集合对象
        private TextBox G_Txt_Name;//定义TextBox类型字段
        private TextBox G_Txt_Age;//定义TextBox类型字段
        private TextBox G_Txt_Chinese;//定义TextBox类型字段
        private TextBox G_Txt_Math;//定义TextBox类型字段
        private TextBox G_Txt_English;//定义TextBox类型字段
        private DataGridView G_Dgv_Data;//定义DataGridView类型字段
        #endregion

        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            #region 添加姓名文本框
            Word.Range P_Range = //得到文档区域
                this.ActiveWindow.Document.Range(ref G_Missing, ref G_Missing);
            P_Range.Text = "姓名：    ";//添加文本内容
            object P_Range_O = Word.WdCollapseDirection.wdCollapseEnd;//创建折叠参数对象
            P_Range.Collapse(ref P_Range_O);//折叠Range
            G_Txt_Name = //添加控件
                this.Controls.AddTextBox(P_Range, 100, 20, "P_Txt_Name");
            #endregion
            #region 添加年龄文本框
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//添加段落
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//添加段落
            P_Range = this.Paragraphs[this.Paragraphs.Count - 1].Range;//得到最后一个段落
            G_Txt_Age = //添加控件
                this.Controls.AddTextBox(P_Range, 100, 20, "P_Txt_Age");
            P_Range = this.Paragraphs[this.Paragraphs.Count - 1].Range;//得到最后一个段落
            object P_Range_O2 = Word.WdCollapseDirection.wdCollapseStart;//创建折叠参数对象
            P_Range.Collapse(ref P_Range_O2);//折叠Range
            P_Range.Text = "年龄：    ";//添加文本
            #endregion
            AddControl(P_Range,P_Range_O);//向文档中添加控件
        }

        private void AddControl(Word.Range P_Range, object P_Range_O)
        {
            #region 添加语文成绩文本框
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;
            P_Range.Text = "语文成绩：";
            P_Range.Collapse(ref P_Range_O);
            G_Txt_Chinese = this.Controls.AddTextBox(P_Range, 100, 20, "P_Txt_Chinese");
            #endregion

            #region 添加数学成绩文本框
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//添加段落
            P_Range = this.Paragraphs[Paragraphs.Count].Range;//得到最后一个段落
            P_Range.Text = "数学成绩：";//添加文本内容
            P_Range.Collapse(ref P_Range_O);//折叠Range
            G_Txt_Math = //添加控件
                this.Controls.AddTextBox(P_Range, 100, 20, "P_Txt_Math");
            #endregion

            #region 添加英语成绩文本框
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//添加段落
            P_Range = this.Paragraphs[Paragraphs.Count].Range;//得到最后一个段落
            P_Range.Text = "英语成绩：";//添加文本内容
            P_Range.Collapse(ref P_Range_O);//折叠Range
            G_Txt_English = //添加控件
                this.Controls.AddTextBox(P_Range, 100, 20, "P_Txt_English");
            #endregion

            #region 添加按钮
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//添加段落
            P_Range = this.Paragraphs[Paragraphs.Count].Range;//得到最后一个段落
            Button P_Btn_OK = //添加按钮控件
                this.Controls.AddButton(P_Range, 100, 20, "P_Btn_OK");
            P_Btn_OK.Click += //为按钮添加事件
                new EventHandler(P_Btn_OK_Click);
            P_Btn_OK.Text = "添加";//设置按钮文本内容
            #endregion

            #region 添加文本内容
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//添加段落
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//添加段落
            P_Range = this.Paragraphs[Paragraphs.Count].Range;//得到最后一个段落
            P_Range.Text = "显示数据：";//显示文本信息
            #endregion

            #region 添加DataGridView控件
            P_Range = this.Paragraphs.Add(ref G_Missing).Range;//添加新段落
            P_Range = this.Paragraphs[Paragraphs.Count].Range;//得到最后一个段落
            G_Dgv_Data = //添加控件
                this.Controls.AddDataGridView(P_Range, 400, 200, "P_Dgv");
            G_Dgv_Data.DataSource = G_List_Student;//将数据绑定到DataGridView控件
            #endregion
        }


        /// <summary>
        /// 点击鼠标按钮事件
        /// </summary>
        /// <param name="sender">按钮对象</param>
        /// <param name="e">事件参数</param>
        void P_Btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                G_List_Student.Add(new Student()//为集合添加对象
                {
                    Name = G_Txt_Name.Text,
                    Age = int.Parse(G_Txt_Age.Text),
                    Chinese = double.Parse(G_Txt_Chinese.Text),
                    Math = double.Parse(G_Txt_Math.Text),
                    English = double.Parse(G_Txt_English.Text)
                });
                G_Dgv_Data.DataSource = null;//绑定数据为空
                G_Dgv_Data.DataSource = G_List_Student;//绑定到集合
                Clear();//清空TextBox控件中的文本内容
            }
            catch (Exception ex)
            {
                MessageBox.Show("请添入正确的数值！\r\n" + ex.Message, "错误！");
            }
        }

        /// <summary>
        /// 清空所有文本框方法
        /// </summary>
        void Clear()
        {
            foreach (Control c in Controls)//遍历控件集合
            {
                TextBox P_TextBox = c as TextBox;//将Control对象转换为TextBox对象
                if (P_TextBox != null)//是否转换成功
                {
                    P_TextBox.Clear();//清空控件中的文本信息
                }
            }
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
