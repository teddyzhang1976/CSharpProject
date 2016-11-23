using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace FileComminuteUnite
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 合并文件
        /// <summary>
        /// 合并文件
        /// </summary>
        /// <param name="list">要合并的文件集合</param>
        /// <param name="strPath">合并后的文件名称</param>
        /// <param name="PBar">进度条显示</param>
        public void CombinFile(string[] strFile, string strPath, ProgressBar PBar)
        {
            PBar.Maximum = strFile.Length;
            FileStream AddStream = null;
            //以合并后的文件名称和打开方式来创建、初始化FileStream文件流
            AddStream = new FileStream(strPath, FileMode.Append);
            //以FileStream文件流来初始化BinaryWriter书写器，此用以合并分割的文件
            BinaryWriter AddWriter = new BinaryWriter(AddStream);
            FileStream TempStream = null;
            BinaryReader TempReader = null;
            //循环合并小文件，并生成合并文件
            for (int i = 0; i < strFile.Length; i++)
            {
                //以小文件所对应的文件名称和打开模式来初始化FileStream文件流，起读取分割作用
                TempStream = new FileStream(strFile[i].ToString(), FileMode.Open);
                TempReader = new BinaryReader(TempStream);
                //读取分割文件中的数据，并生成合并后文件
                AddWriter.Write(TempReader.ReadBytes((int)TempStream.Length));
                //关闭BinaryReader文件阅读器
                TempReader.Close();
                //关闭FileStream文件流
                TempStream.Close();
                PBar.Value = i + 1;
            }
            //关闭BinaryWriter文件书写器
            AddWriter.Close();
            //关闭FileStream文件流
            AddStream.Close();
            MessageBox.Show("文件合并成功！");
        }
        #endregion

        private void frmSplit_Load(object sender, EventArgs e)
        {
            timer1.Start();//启动计时器
        }

        //选择要合成的文件
        private void btnCFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string Selectfile = "";
                string[] files = openFileDialog.FileNames;
                for (int i = 0; i < files.Length; i++)
                {
                    Selectfile += "," + files[i].ToString();
                }
                if (Selectfile.StartsWith(","))
                {
                    Selectfile = Selectfile.Substring(1);
                }
                if (Selectfile.EndsWith(","))
                {
                    Selectfile.Remove(Selectfile.LastIndexOf(","),1);
                }
                txtCFile.Text = Selectfile;
            }
        }

        //选择合成后的文件存放路径
        private void btnCPath_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtCPath.Text = saveFileDialog.FileName;
            }
        }

        //执行合成文件操作
        private void btnCombin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCFile.Text.Trim() == "" || txtCPath.Text.Trim() == "")
                {
                    MessageBox.Show("请将信息输入完整！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtCFile.Text.IndexOf(",") == -1)
                        MessageBox.Show("请选择要合成的文件，最少为两个！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        string[] strFiles = txtCFile.Text.Split(',');
                        CombinFile(strFiles, txtCPath.Text, progressBar);
                    }
                }
            }
            catch { }
        }

        //监视“合并”按钮的可用状态
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtCFile.Text != "" && txtCPath.Text != "")
                btnCombin.Enabled = true;
            else
                btnCombin.Enabled = false;
        }
    }
}