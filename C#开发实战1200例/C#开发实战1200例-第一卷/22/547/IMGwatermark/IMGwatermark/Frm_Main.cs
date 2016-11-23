using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using System.Drawing.Imaging;
namespace IMGwatermark
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }


        #region 获取系统字体
        private void GetSystemFont(ToolStripComboBox cb)
        {
            InstalledFontCollection myFont = new InstalledFontCollection();
            foreach (FontFamily ff in myFont.Families)
            {
                cb.Items.Add(ff.Name);
            }
            cb.SelectedItem = "宋体";
        }
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            cbbPosition.SelectedIndex = 0;
        }

        string [] ImgArray=null;
        string ImgDirectoryPath=null;
        
        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lbImgList.Items.Clear();
                ImgArray = openFileDialog1.FileNames;
                string ImgP = ImgArray[0].ToString();
                ImgP = ImgP.Remove(ImgP.LastIndexOf("\\"));
                ImgDirectoryPath = ImgP;
                for (int i = 0; i < ImgArray.Length; i++)
                {
                    string ImgPath = ImgArray[i].ToString();
                    string ImgName = ImgPath.Substring(ImgPath.LastIndexOf("\\") + 1, ImgPath.Length - ImgPath.LastIndexOf("\\") - 1);
                    lbImgList.Items.Add(ImgName);
                }
                tsslStatus.Text = "图片总数：" + lbImgList.Items.Count;
            }
        }

        private void lbImgList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbImgList.SelectedItems.Count > 0)
            {
                tsslText.Text = "图片位置：" + ImgDirectoryPath + "\\" + lbImgList.SelectedItems[0].ToString();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (lbImgList.Items.Count > 0)
            {
                if (rbTxt.Checked)
                {
                    if (txtWaterMarkFont.Text != "" && txtSavaPath.Text.Trim() != "")
                    {
                        AddFontWatermark(txtWaterMarkFont.Text.Trim(), lbImgList.Items[0].ToString(), 0);
                        Frm_Browser frm2 = new Frm_Browser();
                        frm2.ig = BigBt;
                        frm2.ShowDialog();
                    }
                }
                else
                {
                    if (txtWaterMarkImg.Text != "" && txtSavaPath.Text != "")
                    {
                        ChangeAlpha();
                        AddFontWatermark(txtWaterMarkFont.Text.Trim(), lbImgList.Items[0].ToString(), 2);
                        Frm_Browser frm2 = new Frm_Browser();
                        frm2.ig = BigBt;
                        frm2.ShowDialog();
                    }
                }
            }
        }

        private void trackBar1_Enter(object sender, EventArgs e)
        {
            lbImgList.Focus();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                txtWaterMarkImg.Text = openFileDialog2.FileName;
                if (rbPIC.Checked == true)
                {
                    ChangeAlpha();
                    pbImgPreview.Image = Image.FromFile(txtWaterMarkImg.Text.Trim());
                }
            }
        }

        private void rbTxt_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Enabled = false;
            if(rbPIC.Checked)
            pbImgPreview.Image = null;
        }

        private void rbPIC_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Enabled = true;
            if (rbTxt.Checked)
            {
                pbImgPreview.Image = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lbImgList.Items.Count > 0)
            {
                fontDialog1.ShowColor = true;
                fontDialog1.ShowHelp = false;
                fontDialog1.ShowApply = false;
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    FontF = fontDialog1.Font.FontFamily;
                    fontColor = fontDialog1.Color;
                    fontSize = fontDialog1.Font.Size;
                    fontStyle = fontDialog1.Font.Style;
                    AddFontWatermark(txtWaterMarkFont.Text.Trim(), lbImgList.Items[0].ToString(), 0);
                    pbImgPreview.Image = bt;
                }
            }
        }

        Bitmap bt=null;
        float fontSize = 8;
        Color fontColor=Color.Black;
        FontFamily FontF = null;
        FontStyle fontStyle = FontStyle.Regular;
        int Fwidth;
        int Fheight;
        Bitmap BigBt;
        Font f;
        Brush b;
        private void AddFontWatermark(string txt,string Iname,int i)//预览
        {
            b = new SolidBrush(fontColor);
            bt = new Bitmap(368,75);
            BigBt = new Bitmap(Image.FromFile(ImgDirectoryPath + "\\" +Iname));
            Graphics g = Graphics.FromImage(bt);
            Graphics g1 = Graphics.FromImage(BigBt);
            g.Clear(Color.Gainsboro);
            pbImgPreview.Image = bt;
            if (FontF == null)
            {
                f = new Font(txt,fontSize);
                SizeF XMaxSize = g.MeasureString(txt, f);
                Fwidth = (int)XMaxSize.Width;
                Fheight = (int)XMaxSize.Height;
                g.DrawString(txt,f, b, (int)(368 - Fwidth) / 2, (int)(75 - Fheight) / 2);
                if (cbbPosition.SelectedIndex==0)//正中
                {
                    g1.DrawString(txt, f, b, (int)(BigBt.Width - Fwidth) / 2, (int)(BigBt.Height - Fheight) / 2);
                }
                if (cbbPosition.SelectedIndex == 1)//左上
                {
                    g1.DrawString(txt, f, b, 30,30);
                }
                if (cbbPosition.SelectedIndex ==2)//左下
                {
                    g1.DrawString(txt, f, b, 30, (int)(BigBt.Height - Fheight)-30);
                }
                if (cbbPosition.SelectedIndex == 3) //右上
                {
                    g1.DrawString(txt, f, b, (int)(BigBt.Width - Fwidth), 30);
                }
                if (cbbPosition.SelectedIndex == 4)//右下
                {
                    g1.DrawString(txt, f, b, (int)(BigBt.Width - Fwidth), (int)(BigBt.Height - Fheight)-30);
                }
            }
            else
            {
                f = new Font(FontF, fontSize, fontStyle);
                SizeF XMaxSize = g.MeasureString(txt, f);
                Fwidth = (int)XMaxSize.Width;
                Fheight = (int)XMaxSize.Height;
                g.DrawString(txt, new Font(FontF, fontSize, fontStyle), b, (int)(368 - Fwidth) / 2, (int)(75 - Fheight) / 2);
                if (cbbPosition.SelectedIndex == 0)//正中
                {
                    g1.DrawString(txt, new Font(FontF, fontSize, fontStyle), b, (int)(BigBt.Width - Fwidth) / 2, (int)(BigBt.Height - Fheight) / 2);
                }
                if (cbbPosition.SelectedIndex == 1)//左上
                {
                    g1.DrawString(txt, new Font(FontF, fontSize, fontStyle), b, 30, 30);
                }
                if (cbbPosition.SelectedIndex == 2)//左下
                {
                    g1.DrawString(txt, new Font(FontF, fontSize, fontStyle), b, 30, (int)(BigBt.Height - Fheight)-30);
                }
                if (cbbPosition.SelectedIndex == 3) //右上
                {
                    g1.DrawString(txt, new Font(FontF, fontSize, fontStyle), b, (int)(BigBt.Width - Fwidth), Fheight);
                }
                if (cbbPosition.SelectedIndex == 4)//右下
                {
                    g1.DrawString(txt, new Font(FontF, fontSize, fontStyle), b, (int)(BigBt.Width - Fwidth), (int)(BigBt.Height - Fheight)-30);
                }
            }
            if (i == 1)
            {
                string ipath;
                if (NewFolderPath.Length == 3)
                    ipath = NewFolderPath.Remove(NewFolderPath.LastIndexOf(":") + 1);
                else
                    ipath = NewFolderPath;
                string imgstype = Iname.Substring(Iname.LastIndexOf(".") + 1, Iname.Length - 1 - Iname.LastIndexOf("."));
                if (imgstype.ToLower() == "jpeg" || imgstype.ToLower() == "jpg")
                {
                    BigBt.Save(ipath + "\\_" + Iname, ImageFormat.Jpeg);
                }
                if (imgstype.ToLower() == "png")
                {
                    BigBt.Save(ipath + "\\_" + Iname, ImageFormat.Png);
                }
                if (imgstype.ToLower() == "bmp")
                {
                    BigBt.Save(ipath + "\\_" + Iname, ImageFormat.Bmp);
                }
                if (imgstype.ToLower() == "gif")
                {
                    BigBt.Save(ipath + "\\_" + Iname, ImageFormat.Gif);
                }
                g1.Dispose();
                BigBt.Dispose();
            }
            if (i == 2)
            {
                if (cbbPosition.SelectedIndex == 0)//正中
                {
                    g1.DrawImage(effect, (int)(BigBt.Width - effect.Width) / 2, (int)(BigBt.Height - effect.Height) / 2);
                }
                if (cbbPosition.SelectedIndex == 1)//左上
                {
                    g1.DrawImage(effect, 30, 30);
                }
                if (cbbPosition.SelectedIndex == 2)//左下
                {
                    g1.DrawImage(effect, 30, (int)(BigBt.Height - effect.Height) - 30);
                }
                if (cbbPosition.SelectedIndex == 3) //右上
                {
                    g1.DrawImage(effect, (int)(BigBt.Width - effect.Width)-30, 30);
                }
                if (cbbPosition.SelectedIndex == 4)//右下
                {
                    g1.DrawImage(effect, (int)(BigBt.Width - effect.Width)-30, (int)(BigBt.Height - effect.Height) - 30);
                }
            }
            if (i == 3)
            {
                if (cbbPosition.SelectedIndex == 0)//正中
                {
                    g1.DrawImage(effect, (int)(BigBt.Width - effect.Width) / 2, (int)(BigBt.Height - effect.Height) / 2);
                }
                if (cbbPosition.SelectedIndex == 1)//左上
                {
                    g1.DrawImage(effect, 30, 30);
                }
                if (cbbPosition.SelectedIndex == 2)//左下
                {
                    g1.DrawImage(effect, 30, (int)(BigBt.Height - effect.Height) - 30);
                }
                if (cbbPosition.SelectedIndex == 3) //右上
                {
                    g1.DrawImage(effect, (int)(BigBt.Width - effect.Width), 30);
                }
                if (cbbPosition.SelectedIndex == 4)//右下
                {
                    g1.DrawImage(effect, (int)(BigBt.Width - effect.Width), (int)(BigBt.Height - effect.Height) - 30);
                }
                string ipath;
                if (NewFolderPath.Length == 3)
                    ipath = NewFolderPath.Remove(NewFolderPath.LastIndexOf(":") + 1);
                else
                    ipath = NewFolderPath;
                string imgstype = Iname.Substring(Iname.LastIndexOf(".") + 1, Iname.Length - 1 - Iname.LastIndexOf("."));
                if (imgstype.ToLower() == "jpeg" || imgstype.ToLower() == "jpg")
                {
                    BigBt.Save(ipath + "\\_" + Iname, ImageFormat.Jpeg);
                }
                if (imgstype.ToLower() == "png")
                {
                    BigBt.Save(ipath + "\\_" + Iname, ImageFormat.Png);
                }
                if (imgstype.ToLower() == "bmp")
                {
                    BigBt.Save(ipath + "\\_" + Iname, ImageFormat.Bmp);
                }
                if (imgstype.ToLower() == "gif")
                {
                    BigBt.Save(ipath + "\\_" + Iname, ImageFormat.Gif);
                }
            }
        }
       
        private void txtWaterMarkFont_TextChanged(object sender, EventArgs e)
        {
            if (lbImgList.Items.Count <= 0)
            {
                MessageBox.Show("请加载图片","警告",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                AddFontWatermark(txtWaterMarkFont.Text.Trim(), lbImgList.Items[0].ToString(), 0);
                pbImgPreview.Image = bt;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 调节透明度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        Bitmap effect;
        Bitmap source;
        Image new_img;
        private void ChangeAlpha()
        {
            pbImgPreview.Refresh();
            source = new Bitmap(Image.FromFile(txtWaterMarkImg.Text.Trim()));
            if (source.Width <= 368)
                effect = new Bitmap(368, 75);
            else
            {
                Image.GetThumbnailImageAbort callb = null;
                //对水印图片生成缩略图,缩小到原图得1/4
                new_img = source.GetThumbnailImage(source.Width / 4, source.Width / 4, callb, new System.IntPtr());
                effect = new Bitmap(this.new_img.Width, this.new_img.Height);
            }
            Graphics _effect = Graphics.FromImage(effect);
            float[][] matrixItems ={new float[]{1,0,0,0,0},
                                      new float [] {0,1,0,0,0},
                                      new float []{0,0,1,0,0},
                                      new float []{0,0,0,0,0},
                                      new float[]{0,0,0,trackBar1.Value/255f,1}};
            ColorMatrix imgMatrix = new ColorMatrix(matrixItems);
            ImageAttributes imgEffect = new ImageAttributes();
            imgEffect.SetColorMatrix(imgMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            if (source.Width <= 368)
            {
                _effect.DrawImage(source, new Rectangle(0, 0, 368, 75), 0, 0, 368, 75, GraphicsUnit.Pixel, imgEffect);
            }
            else
            {
                _effect.DrawImage(new_img, new Rectangle(0, 0, new_img.Width, new_img.Height), 0, 0, new_img.Width, new_img.Height, GraphicsUnit.Pixel, imgEffect);
            }
            pbImgPreview.Image = effect;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if(rbPIC.Checked&&txtWaterMarkImg.Text.Trim()!="")
            ChangeAlpha();
        }

        private void btnPerform_Click(object sender, EventArgs e)
        {
            if (rbTxt.Checked&&txtSavaPath.Text!=""&&txtWaterMarkFont.Text!="")
            {
                for (int i = 0; i < lbImgList.Items.Count; i++)
                {
                    AddFontWatermark(txtWaterMarkFont.Text.Trim(), lbImgList.Items[i].ToString(), 1);
                }
                MessageBox.Show("添加水印成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            if (rbPIC.Checked && txtSavaPath.Text != "" && pbImgPreview.Image != null)
            {
                for (int i = 0; i < lbImgList.Items.Count; i++)
                {
                    AddFontWatermark(txtWaterMarkFont.Text.Trim(), lbImgList.Items[i].ToString(),3);
                }
                MessageBox.Show("添加水印成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        string NewFolderPath;
        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSavaPath.Text = folderBrowserDialog1.SelectedPath;
                NewFolderPath = txtSavaPath.Text.Trim();
            }
        }

    }
}
