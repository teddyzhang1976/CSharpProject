using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RefreshFormByChildForm
{
    public delegate void UpdateDataHandler();

    public partial class Frm_Child : Form
    {
        public Frm_Child()
        {
            InitializeComponent();
        }
        ///<summary>
        /// 本实例仅可创建一个窗口，因此在这里屏蔽关闭按钮;最大化后没有实际意义，因此关闭MaximizeBox属性值为False
        ///</summary>

        #region 变量的声明
       // public event EventHandler UpdateDataGridView = null;//定义一个处理更新DataGridView控件内容的方法
        public static string DeleteID;  //定义一个表示删除数据编号的字符串
        public static string idContent; //该变量用来存储数据编号
        public static string nameContent;//该变量用来存储姓名
        public static string phoneContent;//该变量用来存储电话
        public static string addressContent;//该变量用来存储住址
        public static bool GlobalFlag; //该变量用来标识是否创建新的子窗体
        #endregion

        #region 自己添加的委托
        public UpdateDataHandler OnUpdateDataGridView;
        #endregion

        protected void UpdateData()
        {
            /*if (UpdateDataGridView != null)//当触发更新DataGridView事件时
            {
                UpdateDataGridView(this, EventArgs.Empty);//更新DataGridView控件中的内容
            }*/

            if (OnUpdateDataGridView != null)
            {
                OnUpdateDataGridView();
            }
        }

        private void Frm_Child_FormClosing(object sender, FormClosingEventArgs e)
        {
            Frm_Main.flag = false; //设定该值为false表示可以创建新窗体
        }

        private void Frm_Child_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Frm_Main.IDArray.Length; i++) //循环遍历数组中的每一个元素
            {
                comboBox1.Items.Add(Frm_Main.IDArray[i].ToString());//向Combobox控件中添加内容
                comboBox1.SelectedIndex = 0;//设定当前选中项的索引为0
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            GlobalFlag = false; //设定全局变量表示为false
            if (comboBox1.Items.Count > 1)//当ComboBox中剩不小于2条内容时
            {
                DeleteID = comboBox1.SelectedItem.ToString();//将选中项转化为int型
                if (comboBox1.Items.Count != 0)//当ComboBox中剩1条内容时
                {
                    comboBox1.Items.Remove(comboBox1.SelectedItem);
                    comboBox1.SelectedIndex = 0;
                }
            }
            UpdateData();//更新Combobox控件中的内容
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            id.Clear(); //清空编号文本框中的内容
            name.Clear();//清空姓名文本框中的内容
            phone.Clear();//清空电话号码文本框中的内容
            address.Clear();//清空居住地址文本框中的内容
            id.Focus();//设定当前鼠标的焦点在编号文本框中
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            GlobalFlag = true; //设定标识的值为true
            if (!(comboBox1.Items.Equals(idContent)))//当Combobox控件中不存在将添加的信息时
            {
                comboBox1.Items.Add(idContent);//在Combobox控件中添加一条记录
            }
            UpdateData();
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            idContent = id.Text; //保存新添加记录的编号
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            nameContent = name.Text;//保存填入的姓名
        }

        private void phone_TextChanged(object sender, EventArgs e)
        {
            phoneContent = phone.Text;//保存填入的电话号码
        }

        private void address_TextChanged(object sender, EventArgs e)
        {
            addressContent = address.Text;//保存填入的地址信息
        }
    }
}
