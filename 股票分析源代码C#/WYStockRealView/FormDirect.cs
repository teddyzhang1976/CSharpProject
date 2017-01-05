using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace WYStockRealView
{
    public partial class FormDirect : Form
    {
        public FormDirect()
        {
            InitializeComponent();
        }

        private void RealTimebutton_Click(object sender, EventArgs e)
        {
            RealTimeForm rtf = new RealTimeForm();
            rtf.Show();
        }

        private void Klinebutton_Click(object sender, EventArgs e)
        {
            KLineForm kf = new KLineForm();
            kf.Show();
        }

        private void PICDEMO_Click(object sender, EventArgs e)
        {
            ZedGraph.Demo.DemoTabForm dtf = new ZedGraph.Demo.DemoTabForm();
            dtf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoreKLineForm mkf = new MoreKLineForm();
            mkf.Show();
        }
        System.IO.FileSystemWatcher SIFSW = new FileSystemWatcher();
        private void button2_Click(object sender, EventArgs e)
        {
            //SIFSW.BeginInit();
            SIFSW.Path = @"D:\Program Files\wyc";
            SIFSW.Filter = "*.*";
            SIFSW.IncludeSubdirectories = true;         
            SIFSW.Created += new FileSystemEventHandler(SIFSW_Created);
            SIFSW.Changed += new FileSystemEventHandler(SIFSW_Changed);
            SIFSW.Deleted += new FileSystemEventHandler(SIFSW_Deleted);
            SIFSW.EnableRaisingEvents = true;
       
        }

        void SIFSW_Deleted(object sender, FileSystemEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            Console.WriteLine("Del:"+e.FullPath);
        }

        void SIFSW_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Change:" + e.FullPath);
           // throw new Exception("The method or operation is not implemented.");
        }

        void SIFSW_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Create:" + e.FullPath);
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}