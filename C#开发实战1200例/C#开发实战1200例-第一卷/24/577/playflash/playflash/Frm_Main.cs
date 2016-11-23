using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace playflash
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        AxShockwaveFlashObjects.AxShockwaveFlash ax;//创建AxShockwaveFlash实例

        private void AddFlash()
        {
            ax = new AxShockwaveFlashObjects.AxShockwaveFlash();			//实例化AxShockwaveFlash对象
            panel1.Controls.Add(ax);									//添加到Panel控件中
            ax.Dock = DockStyle.Fill;									//设置填充模式
            ax.ScaleMode = 1;
            ax.Stop();												//停止，不播放
        }

        private void ControlState(int i)
        {
            if (i == 0)
            {
                播放ToolStripMenuItem.Enabled = false;
                第一帧ToolStripMenuItem.Enabled = false;
                向前ToolStripMenuItem.Enabled = false;
                向后ToolStripMenuItem.Enabled = false;
            }
            else
            {
                播放ToolStripMenuItem.Enabled = true;
                第一帧ToolStripMenuItem.Enabled = true;
                向前ToolStripMenuItem.Enabled = true;
                向后ToolStripMenuItem.Enabled = true;
            }
        }


        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)				//如果选择了FLASH文件
            {
                ax.Visible = true;										//显示播放器
                string flashPath = openFileDialog1.FileName;					//获取FLASH文件路径
                ax.Movie = flashPath;									//设置播放器的Movie属性
                panel1.Visible = true;									//显示Panel控件
                ControlState(1);										//激活菜单
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            AddFlash();												//窗体加载时添加播放器
            ax.Visible = false;											//隐藏播放器
            ControlState(0);											//设置菜单状态
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ax.Dispose();
            AddFlash();
            ControlState(0);
            ax.Stop();
            ax.Visible = false;
        }

        private void 向前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ax.Back();// Back方法播放上一帧
        }

        private void 向后ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ax.Forward();// Forward方法播放下一帧
        }

        private void 第一帧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ax.Rewind();// Rewind方法播放第一帧
        }

        private void 播放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (播放ToolStripMenuItem.CheckState  == CheckState.Checked)
            {
                播放ToolStripMenuItem.CheckState = CheckState.Unchecked;
                ax.Stop();
            }
            else
            {
                播放ToolStripMenuItem.CheckState = CheckState.Checked;
                ax.Play();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ax.Playing == true)
            {
                播放ToolStripMenuItem.CheckState = CheckState.Checked;
            }
            else
            {
                播放ToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Size  s=new Size(423,386);
            if (this.Size == s)
            {
                panel1.Visible = true;
            }
            else
            {
                if (ax.Playing == false)
                {
                    this.BackColor = Color.Black;
                    panel1.Visible = false;
                }
            }
        }
    }
}                                                                                                                                                                                                                                                                   
