using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
namespace IMGAddDate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        public string flag = null;
        PropertyItem[] pi;
        string TakePicDateTime;
        int SpaceLocation;
        string pdt;
        string ptm;
        Bitmap Pic;
        Graphics g;
        Thread td;
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] IMG;
            listBox1.Items.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IMG = openFileDialog1.FileNames;
                if (IMG.Length > 0)
                {
                    for (int i = 0; i < IMG.Length; i++)
                    {
                        listBox1.Items.Add(IMG[i]);
                    }
                }
                flag = IMG.Length.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            flag = null;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSavePath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flag == null || txtSavePath.Text == "")
            {
                return;
            }
            else
            {
                toolStripProgressBar1.Visible = true;
                td = new Thread(new ThreadStart(AddDate));
                td.Start();
            }
        }

        private void AddDate()
        {
            Font normalContentFont = new Font("宋体", 36,FontStyle.Bold);
            Color normalContentColor = Color.Red;
            int kk = 1;
            toolStripProgressBar1.Maximum = listBox1.Items.Count;
            toolStripProgressBar1.Minimum = 1;
            toolStripStatusLabel1.Text = "开始添加数码相片拍摄日期";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                pi = GetExif(listBox1.Items[i].ToString());
                //获取元数据中的拍照日期时间，以字符串形式保存
                TakePicDateTime = GetDateTime(pi);
                //分析字符串分别保存拍照日期和时间的标准格式
                SpaceLocation = TakePicDateTime.IndexOf(" ");
                pdt = TakePicDateTime.Substring(0, SpaceLocation);
                pdt = pdt.Replace(":", "-");
                ptm = TakePicDateTime.Substring(SpaceLocation + 1, TakePicDateTime.Length - SpaceLocation - 2);
                TakePicDateTime = pdt + " " + ptm;
                //由列表中的文件创建内存位图对象
                Pic = new Bitmap(listBox1.Items[i].ToString());
                //由位图对象创建Graphics对象的实例
                g = Graphics.FromImage(Pic);
                //绘制数码照片的日期/时间
                g.DrawString(TakePicDateTime, normalContentFont, new SolidBrush(normalContentColor),
            Pic.Width - 700, Pic.Height - 200);
                //将添加日期/时间戳后的图像进行保存
                if (txtSavePath.Text.Length == 3)
                {
                    Pic.Save(txtSavePath.Text + Path.GetFileName(listBox1.Items[i].ToString()));
                }
                else
                {
                    Pic.Save(txtSavePath.Text +"\\"+ Path.GetFileName(listBox1.Items[i].ToString()));
                }
                //释放内存位图对象
                Pic.Dispose();
                toolStripProgressBar1.Value = kk;
                if (kk == listBox1.Items.Count)
                {
                    toolStripStatusLabel1.Text = "全部数码相片拍摄日期添加成功";
                    toolStripProgressBar1.Visible = false;
                    flag = null;
                    listBox1.Items.Clear();
                }
                kk++;
            }
        }

        #region 获取数码相片的拍摄日期
        //获取图像文件的所有元数据属性，保存倒PropertyItem数组
        public static PropertyItem[] GetExif(string fileName)
        {
            FileStream Mystream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //通过指定的数据流来创建Image
            Image image = Image.FromStream(Mystream, true, false);
            return image.PropertyItems;
        }

        //遍历所有元数据，获取拍照日期/时间
        private string GetDateTime(System.Drawing.Imaging.PropertyItem[] parr)
        {
            Encoding ascii = Encoding.ASCII;
            //遍历图像文件元数据，检索所有属性
            foreach (PropertyItem pp in parr)
            {
                //如果是PropertyTagDateTime，则返回该属性所对应的值
                if (pp.Id == 0x0132)
                {
                    return ascii.GetString(pp.Value);
                }
            }
            //若没有相关的EXIF信息则返回N/A
            return "N/A";
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(td!=null)
            {
                td.Abort();
            }
        }
    }
}
