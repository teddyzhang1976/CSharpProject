using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwitchInput
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //获取系统中已经安装的文字输入法
            InputLanguageCollection mInputs = InputLanguage.InstalledInputLanguages;
            foreach (InputLanguage mInput in mInputs)
                this.comboBox1.Items.Add(mInput.LayoutName);
            //获取当前输入法信息
            InputLanguage CurrentInput = InputLanguage.CurrentInputLanguage;
            this.textBox1.Text = CurrentInput.LayoutName;
            //获取输入法的语言区域
            this.textBox3.Text = CurrentInput.Culture.DisplayName;
            //获取默认的输入法信息
            InputLanguage dInput = InputLanguage.DefaultInputLanguage;
            this.textBox2.Text = dInput.LayoutName;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取选择的输入法
            InputLanguage mInput = InputLanguage.InstalledInputLanguages[comboBox1.SelectedIndex];
            //设置当前输入法
            InputLanguage.CurrentInputLanguage = mInput;
            //获取当前输入法信息
            InputLanguage CurrentInput = InputLanguage.CurrentInputLanguage;
            this.textBox1.Text = CurrentInput.LayoutName;
            //获取输入法的语言区域
            this.textBox3.Text = CurrentInput.Culture.DisplayName;
            //获取默认的输入法信息
            InputLanguage dInput = InputLanguage.DefaultInputLanguage;
            this.textBox2.Text = dInput.LayoutName;	
        }
    }
}
