using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalcRMatrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //定义3个float类型的二维数组，作为矩阵
            float[,] MatrixEin = new float[3, 3];
            float[,] MatrixZwei = new float[3, 3];
            float[,] MatrixResult = new float[3, 3];
            //为第一个矩阵中的各个项赋值
            MatrixEin[0, 0] = 2;
            MatrixEin[0, 1] = 2;
            MatrixEin[0, 2] = 1;
            MatrixEin[1, 0] = 1;
            MatrixEin[1, 1] = 1;
            MatrixEin[1, 2] = 1;
            MatrixEin[2, 0] = 1;
            MatrixEin[2, 1] = 0;
            MatrixEin[2, 2] = 1;
            //为第二个矩阵中的各个项赋值
            MatrixZwei[0, 0] = 0;
            MatrixZwei[0, 1] = 1;
            MatrixZwei[0, 2] = 2;
            MatrixZwei[1, 0] = 0;
            MatrixZwei[1, 1] = 1;
            MatrixZwei[1, 2] = 1;
            MatrixZwei[2, 0] = 0;
            MatrixZwei[2, 1] = 1;
            MatrixZwei[2, 2] = 2;
            lab_First.Text += "第一个矩阵：\n";
            //循环遍历第一个矩阵并输出
            for (int i = 0; i < 3; i++)
            {
                lab_First.Text += "|     ";
                for (int j = 0; j < 3; j++)
                {
                    lab_First.Text += MatrixEin[i, j] + "   ";
                }
                lab_First.Text += "   |\r\n";
            }
            lab_Second.Text = "第二个矩阵：\n";
            //循环遍历第二个矩阵并输出
            for (int i = 0; i < 3; i++)
            {
                lab_Second.Text += "|     ";
                for (int j = 0; j < 3; j++)
                {
                    lab_Second.Text += MatrixZwei[i, j] + "   ";
                }
                lab_Second.Text += "   |\r\n";
            }
            MultiplyMatrix(MatrixEin, MatrixZwei, MatrixResult);//调用自定义方法计算两个矩阵的乘积
            lab_Result.Text = "两个矩阵的乘积：\n";
            //循环遍历新得到的矩阵并输出
            for (int i = 0; i < 3; i++)
            {
                lab_Result.Text += "|     ";
                for (int j = 0; j < 3; j++)
                {
                    lab_Result.Text += MatrixResult[i, j] + "   ";
                }
                lab_Result.Text += "   |\r\n";
            }
        }

        #region 矩阵乘法
        public void MultiplyMatrix(float[,] MatrixEin, float[,] MatrixZwei, float[,] MatrixResult)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        MatrixResult[i, j] += MatrixEin[i, k] * MatrixZwei[k, j];//计算矩阵的乘积
                    }
                }
            }
        }
        #endregion
    }
}
