using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;
using System.IO;
namespace BatchDecompression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 压缩文件及文件夹
        /// <summary>
        /// 递归压缩文件夹方法
        /// </summary>
        /// <param name="FolderToZip"></param>
        /// <param name="ZOPStream">压缩文件输出流对象</param>
        /// <param name="ParentFolderName"></param>
        private bool ZipFileDictory(string FolderToZip, ZipOutputStream ZOPStream, string ParentFolderName)
        {
            bool res = true;
            string[] folders, filenames;
            ZipEntry entry = null;
            FileStream fs = null;
            Crc32 crc = new Crc32();
            try
            {
                //创建当前文件夹
                entry = new ZipEntry(Path.Combine(ParentFolderName, Path.GetFileName(FolderToZip) + "/"));  //加上 “/” 才会当成是文件夹创建
                ZOPStream.PutNextEntry(entry);
                ZOPStream.Flush();
                //先压缩文件，再递归压缩文件夹 
                filenames = Directory.GetFiles(FolderToZip);
                foreach (string file in filenames)
                {
                    //打开压缩文件
                    fs = File.OpenRead(file);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    entry = new ZipEntry(Path.Combine(ParentFolderName, Path.GetFileName(FolderToZip) + "/" + Path.GetFileName(file)));
                    entry.DateTime = DateTime.Now;
                    entry.Size = fs.Length;
                    fs.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    ZOPStream.PutNextEntry(entry);
                    ZOPStream.Write(buffer, 0, buffer.Length);
                }
            }
            catch
            {
                res = false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs = null;
                }
                if (entry != null)
                {
                    entry = null;
                }
                GC.Collect();
                GC.Collect(1);
            }
            folders = Directory.GetDirectories(FolderToZip);
            foreach (string folder in folders)
            {
                if (!ZipFileDictory(folder, ZOPStream, Path.Combine(ParentFolderName, Path.GetFileName(FolderToZip))))
                {
                    return false;
                }
            }

            return res;
        }

        /// <summary>
        /// 压缩目录
        /// </summary>
        /// <param name="FolderToZip">待压缩的文件夹</param>
        /// <param name="ZipedFile">压缩后的文件名</param>
        /// <returns></returns>
        private bool ZipFileDictory(string FolderToZip, string ZipedFile)
        {
            bool res;
            if (!Directory.Exists(FolderToZip))
            {
                return false;
            }
            ZipOutputStream ZOPStream = new ZipOutputStream(File.Create(ZipedFile));
            ZOPStream.SetLevel(6);
            res = ZipFileDictory(FolderToZip, ZOPStream, "");
            ZOPStream.Finish();
            ZOPStream.Close();
            return res;
        }

        /// <summary>
        /// 压缩文件和文件夹
        /// </summary>
        /// <param name="FileToZip">待压缩的文件或文件夹</param>
        /// <param name="ZipedFile">压缩后生成的压缩文件名，全路径格式</param>
        /// <returns></returns>
        public bool Zip(String FileToZip, String ZipedFile)
        {
            if (Directory.Exists(FileToZip))
            {
                return ZipFileDictory(FileToZip, ZipedFile);
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 复制文件//
        public void CopyFile(string[] list,string strNewPath,ToolStripProgressBar TSPBar)
        {
            try
            {
                TSPBar.Maximum = list.Length;
                string strNewFile = "c:\\" + strNewPath;
                if (!Directory.Exists(strNewFile))
                    Directory.CreateDirectory(strNewFile);
                foreach (object objFile in list)
                {
                    string strFile = objFile.ToString();
                    string Filename = strFile.Substring(strFile.LastIndexOf("\\") + 1, strFile.Length - strFile.LastIndexOf("\\") - 1);
                    File.Copy(strFile, strNewFile+"\\"+Filename, true);
                    TSPBar.Value += 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 解压文件
        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="FileToUpZip">待解压的文件</param>
        /// <param name="ZipedFolder">指定解压目标目录</param>
        public void UnZip(string FileToUpZip, string ZipedFolder)
        {
            if (!File.Exists(FileToUpZip))
            {
                return;
            }
            if (!Directory.Exists(ZipedFolder))
            {
                Directory.CreateDirectory(ZipedFolder);
            }
            ZipInputStream ZIPStream = null;
            ZipEntry theEntry = null;
            string fileName;
            FileStream streamWriter = null;
            try
            {
                //生成一个GZipInputStream流，用来打开压缩文件
                ZIPStream = new ZipInputStream(File.OpenRead(FileToUpZip));
                while ((theEntry = ZIPStream.GetNextEntry()) != null)
                {
                    if (theEntry.Name != String.Empty)
                    {
                        fileName = Path.Combine(ZipedFolder, theEntry.Name);
                        //判断文件路径是否是文件夹
                        if (fileName.EndsWith("/") || fileName.EndsWith("\\"))
                        {
                            Directory.CreateDirectory(fileName);
                            continue;
                        }
                        //生成一个文件流，它用来生成解压文件
                        streamWriter = File.Create(fileName);
                        int size = 2048;//指定压缩块的大小，一般为2048的倍数
                        byte[] data = new byte[2048];//指定缓冲区的大小
                        while (true)
                        {
                            size = ZIPStream.Read(data, 0, data.Length);//读入一个压缩块
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);//写入解压文件代表的文件流
                            }
                            else
                            {
                                break;//若读到压缩文件尾，则结束 
                            }
                        }
                    }
                }
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter = null;
                }
                if (theEntry != null)
                {
                    theEntry = null;
                }
                if (ZIPStream != null)
                {
                    ZIPStream.Close();
                    ZIPStream = null;
                }
                GC.Collect();
                GC.Collect(1);
            }
        }
        #endregion

        string[] files;//存储要进行压缩的文件数组
        string[] files2;//存储要进行解压缩的文件数组
        private void button1_Click(object sender, EventArgs e)//选择批量压缩的文件
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                files = openFileDialog1.FileNames;
                string file = "";
                for (int i = 0; i < files.Length; i++)
                {
                    file += files[i].ToString() + ",";
                }
                file = file.Remove(file.LastIndexOf(","));
                txtfiles.Text = file;
            }
        }

        private void button3_Click(object sender, EventArgs e)//选择批量解压缩的文件
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                files2 = openFileDialog2.FileNames;
                string file = "";
                for (int i = 0; i < files2.Length; i++)
                {
                    file += files2[i].ToString() + ",";
                }
                file = file.Remove(file.LastIndexOf(","));
                txtfiles2.Text = file;
            }
        }

        private void button2_Click(object sender, EventArgs e)//批量压缩
        {
            try
            {
                if (txtfiles.Text.Trim()!="")
                {
                    toolStripProgressBar1.Maximum = files.Length;
                    if (files.Length > 1)
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            string strNewPath = DateTime.Now.ToString("yyyyMMddhhmmss");
                            CopyFile(files, strNewPath, toolStripProgressBar1);
                            Zip("c:\\"+strNewPath,saveFileDialog1.FileName);
                            Directory.Delete("c:\\" + strNewPath, true);
                            MessageBox.Show("压缩文件成功");
                        }
                    }
                    toolStripProgressBar1.Value = 0;
                }
                else
                {
                    MessageBox.Show("警告：请选择要进行批量压缩的文件！","警告",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfiles2.Text.Trim() != "")
                {
                    toolStripProgressBar1.Maximum = files2.Length;
                    for (int i = 0; i < files2.Length; i++)
                    {
                        toolStripProgressBar1.Value = i;
                        string path = files2[i].ToString();
                        string newpath = path.Remove(path.LastIndexOf("\\") + 1);
                        UnZip(path, newpath);
                    }
                    toolStripProgressBar1.Value = 0;
                    MessageBox.Show("解压缩成功！");
                }
                else
                {
                    MessageBox.Show("警告：请选择要进行批量解压缩的文件！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
                
        }
    }
}
