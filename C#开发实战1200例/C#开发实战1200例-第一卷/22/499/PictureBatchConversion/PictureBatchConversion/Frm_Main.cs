using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace PictureBatchConversion
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        string[] path1=null;                 //用于存储选择的文件列表
        string path2="";                    //用于存储保存的路径
        Bitmap bt;                          //声明一个转换图片格式的Bitmap对象
        Thread td;                          //声明一个线程
        int Imgtype1;                       //声明一个变量用于标记ConvertImage方法中转换的类型
        string OlePath;                     //声明一个变量用于存储ConvertImage方法中原始图片的路径
        string path;                        //声明一个变量用于存储ConvertImage方法中转换后图片的保存路径
        int flags;                           //用于标记已转换图片的数量，用于计算转换进度

        private void Form2_Load(object sender, EventArgs e) 
        {
            tscbType.SelectedIndex = 0;             //设置第一个转换类型被选中
            CheckForIllegalCrossThreadCalls = false;//屏蔽线程弹出的错误提示
        }
        private void toolStripButton3_Click(object sender, EventArgs e)//选择转换文件的按钮
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)        //判断是否选择文件
            {
                listView1.Items.Clear();                                //清空listView1
                string[] info = new string[7];                          //存储每一行数据
                FileInfo fi;                                            //创建一个FileInfo对象，用于获取图片信息
                path1 = openFileDialog1.FileNames;                      //获取选择的图片集合
                for (int i = 0; i < path1.Length; i++)                  //读取集合中的内容
                {
                    //获取图片名称
                    string ImgName = path1[i].Substring(path1[i].LastIndexOf("\\") + 1, path1[i].Length - path1[i].LastIndexOf("\\") - 1);
                    //获取图片类型
                    string ImgType = ImgName.Substring(ImgName.LastIndexOf(".") + 1, ImgName.Length - ImgName.LastIndexOf(".") - 1);
                    fi = new FileInfo(path1[i].ToString());             //实例化FileInfo对象
                    //将每一行数据第一个位置的图标添加到imageList1中
                    imageList1.Images.Add(ImgName,Properties.Resources.图标__23_);
                    info[1] = ImgName;                      //图片名称
                    info[2] = ImgType;                      //图片类型
                    info[3] = fi.LastWriteTime.ToShortDateString();//图片最后修改日期
                    info[4] = path1[i].ToString();                  //图片位置
                    info[5] = (fi.Length/1024)+"KB";                //图片大小
                    info[6] = "未转换";                                //图片状态
                    ListViewItem lvi = new ListViewItem(info, ImgName);  //实例化ListViewItem对象
                    listView1.Items.Add(lvi);                              //将信息添加到listView1控件中
                }
                tsslFileNum.Text = "当前共有" + path1.Length.ToString() + "个文件";//状态栏中显示图片数量
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e) //关闭按钮
        {
            Application.Exit();                                         //退出系统
        }

        private void toolStripButton5_Click(object sender, EventArgs e) //清空列表的按钮
        {   
            listView1.Items.Clear();                                        //清空列表
            path1 = null;                                                   //清空图片的集合
            tsslFileNum.Text = "当前没有文件";                                 //状态栏中提示
            tsslPlan.Text = "";                                                 //清空进度数字
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (path1 == null)                                              //判断是否选择图片
            {
                MessageBox.Show("请选择图片！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (path2.Length == 0)                                      //判断是否选择保存位置
                {
                    MessageBox.Show("请选择保存位置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    flags = 1;                                              //初始化flags变量为1，用于计算进度
                    toolStrip1.Enabled = false;                             //当转换开始时，禁用工具栏
                    int flag = tscbType.SelectedIndex;                      //判断将图片转换为何种格式
                    switch (flag)                                           //根据不同的格式进行转换
                    {
                        case 0:
                            Imgtype1 = 0;                                   //如果选择第一项则转换为BMP格式
                            td = new Thread(new ThreadStart(ConvertImage)); //通过线程调用ConvertImage方法进行转换
                            td.Start();
                            break;
                        case 1:                                             //如果选择第二项则转换为JPG格式
                            Imgtype1 = 1;
                            td = new Thread(new ThreadStart(ConvertImage));//通过线程调用ConvertImage方法进行转换
                            td.Start();
                            break;
                        case 2:                                            //如果选择第三项则转换为PNG格式
                            Imgtype1 = 2;
                            td = new Thread(new ThreadStart(ConvertImage));//通过线程调用ConvertImage方法进行转换
                            td.Start();
                            break;
                        case 3:                                             //如果选择第四项则转换为GIF格式
                            Imgtype1 = 3;
                            td = new Thread(new ThreadStart(ConvertImage));//通过线程调用ConvertImage方法进行转换
                            td.Start();
                            break;
                        default: td.Abort(); break;
                    }
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)//选择保存路径按钮
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)   //判断是否选择保存路径
            {
                path2 = folderBrowserDialog1.SelectedPath;              //获取保存路径
            }
        }

        private void ConvertImage()
        {
            flags = 1;
            switch (Imgtype1)
            {
                case 0: 
                    for (int i = 0; i < path1.Length; i++)
                    {
                        string ImgName = path1[i].Substring(path1[i].LastIndexOf("\\") + 1, path1[i].Length - path1[i].LastIndexOf("\\") - 1);
                        ImgName = ImgName.Remove(ImgName.LastIndexOf("."));
                        OlePath = path1[i].ToString();
                        bt = new Bitmap(OlePath);
                        path = path2 + "\\" + ImgName + ".bmp";
                        bt.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
                        listView1.Items[flags - 1].SubItems[6].Text = "已转换";
                        tsslPlan.Text = "正在转换"+flags*100/path1.Length+"%";
                        if (flags == path1.Length)
                        {
                            toolStrip1.Enabled = true;
                            tsslPlan.Text = "图片转换全部完成";
                        }
                        flags++;
                    }
                    break;
                case 1:
                    for (int i = 0; i < path1.Length; i++)
                    {
                        string ImgName = path1[i].Substring(path1[i].LastIndexOf("\\") + 1, path1[i].Length - path1[i].LastIndexOf("\\") - 1);
                        ImgName = ImgName.Remove(ImgName.LastIndexOf("."));
                        OlePath = path1[i].ToString();
                        bt = new Bitmap(OlePath);
                        path = path2 + "\\" + ImgName + ".jpeg";
                        bt.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                        listView1.Items[flags - 1].SubItems[6].Text = "已转换";
                        tsslPlan.Text = "正在转换" + flags * 100 / path1.Length + "%";
                        if (flags == path1.Length)
                        {
                            toolStrip1.Enabled = true;
                            tsslPlan.Text = "图片转换全部完成";
                        }
                        flags++;
                    }
                    break;
                case 2:
                    for (int i = 0; i < path1.Length; i++)
                    {
                        string ImgName = path1[i].Substring(path1[i].LastIndexOf("\\") + 1, path1[i].Length - path1[i].LastIndexOf("\\") - 1);
                        ImgName = ImgName.Remove(ImgName.LastIndexOf("."));
                        OlePath = path1[i].ToString();
                        bt = new Bitmap(OlePath);
                        path = path2 + "\\" + ImgName + ".png";
                        bt.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                        listView1.Items[flags - 1].SubItems[6].Text = "已转换";
                        tsslPlan.Text = "正在转换" + flags * 100 / path1.Length + "%";
                        if (flags == path1.Length)
                        {
                            toolStrip1.Enabled = true;
                            tsslPlan.Text = "图片转换全部完成";
                        }
                        flags++;
                    }
                    break;
                case 3:
                    for (int i = 0; i < path1.Length; i++)
                    {
                        string ImgName = path1[i].Substring(path1[i].LastIndexOf("\\") + 1, path1[i].Length - path1[i].LastIndexOf("\\") - 1);
                        ImgName = ImgName.Remove(ImgName.LastIndexOf("."));
                        OlePath = path1[i].ToString();
                        bt = new Bitmap(OlePath);
                        path = path2 + "\\" + ImgName + ".gif";
                        bt.Save(path, System.Drawing.Imaging.ImageFormat.Gif);
                        listView1.Items[flags - 1].SubItems[6].Text = "已转换";
                        tsslPlan.Text = "正在转换" + flags * 100 / path1.Length + "%";
                        if (flags == path1.Length)
                        {
                            toolStrip1.Enabled = true;
                            tsslPlan.Text = "图片转换全部完成";
                        }
                        flags++;
                    }
                    break;
                default: bt.Dispose(); break;
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)//关闭窗口时要关闭线程
        {
            if (td != null)                                                 //判断是否存在线程
            {
                if (td.ThreadState == ThreadState.Running)                  //然后判断线程是否正在运行
                {
                    td.Abort();                                             //如果运行则关闭线程
                }
            }
        }
    }
}
