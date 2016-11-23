using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace EncryptDataset
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private static byte[] desKey = new byte[] { 11, 23, 93, 102, 72, 41, 18, 12 };
        //获取或设置对称算法的初始化向量
        private static byte[] desSIV = new byte[] { 75, 158, 46, 97, 78, 57, 17, 36 };
        string P_str_Con = "Server=LVSHUANG\\SHJ;database=db_TomeTwo;Uid=sa;Pwd=hbyt2008!@#;";//定义数据库连接字符串

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(P_str_Con);//创建数据库连接对象
            SqlDataAdapter dap = new SqlDataAdapter("select * from tb_Employee", con);//创建数据桥接器对象
            DataSet ds = new DataSet();//创建DataSet数据集
            dap.Fill(ds);//填充数据集
            dataGridView1.DataSource = ds.Tables[0];//对DataGridView控件进行数据绑定
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(P_str_Con);//创建数据库连接对象
            SqlDataAdapter dap = new SqlDataAdapter("select * from tb_Employee", con);//创建数据桥接器对象
            DataSet ds = new DataSet();//创建DataSet数据集
            dap.Fill(ds);//填充数据集
            EncryptDataSetToXML(ds, "DataSet.xml");//加密DataSet数据集
            dataGridView1.DataSource = ds.Tables[0];//对DataGridView控件进行数据绑定
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DecryptDataSetFromXML("DataSet.xml").Tables[0];//显示解密数据
        }

        public static void EncryptDataSetToXML(DataSet dataSet, string outXMLFilePath)
        {
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();//创建DES算法提供者对象
            FileStream fout = new FileStream(outXMLFilePath, FileMode.OpenOrCreate, FileAccess.Write);//创建FileStream对象
            //用指定的 Key 和初始化向量 (IV) 创建对称数据加密标准 (DES) 加密器对象
            CryptoStream objCryptoStream = new CryptoStream(fout, objDES.CreateEncryptor(desKey, desSIV), CryptoStreamMode.Write);
            StreamWriter objStreamWriter = new StreamWriter(objCryptoStream);//创建写入流对象
            XmlSerializer objXMLSer = new XmlSerializer(typeof(DataSet));//创建XML序列化对象
            objXMLSer.Serialize(objStreamWriter, dataSet);//对数据集进行序列化
            objStreamWriter.Close();//释放写入流对象
        }
        public static DataSet DecryptDataSetFromXML(string inXMLFilePath)
        {
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();//创建DES算法提供者对象
            FileStream fin = new FileStream(inXMLFilePath, FileMode.Open, FileAccess.Read);//创建FileStream对象
            //用指定的 Key 和初始化向量 (IV) 创建对称数据加密标准 (DES) 解密器对象
            CryptoStream objCryptoStream = new CryptoStream(fin, objDES.CreateDecryptor(desKey, desSIV), CryptoStreamMode.Read);
            TextReader objTxrReader = new StreamReader(objCryptoStream);//创建读取流对象
            XmlSerializer objXMLSer = new XmlSerializer(typeof(DataSet));//创建XML序列化对象
            DataSet ds = (DataSet)objXMLSer.Deserialize(objTxrReader);//对流进行反序列化
            return ds;//返回数据集
        }
    }
}
