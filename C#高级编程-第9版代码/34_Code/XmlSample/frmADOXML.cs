using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XmlSample
{
	public partial class frmADOXML : Form
	{
        string _connectString = "Server=WIN8MBP\\SQLEXPRESS; Database=adventureworkslt2012;Trusted_Connection=Yes";
		

		public frmADOXML()
		{
			InitializeComponent();
		}

        
        private void button1_Click(object sender, EventArgs e)
		{
            XmlDocument doc = new XmlDocument();
			//create a dataset
			DataSet ds = new DataSet("XMLProducts");
			//connect to the northwind database and 
			//select all of the rows from products table
            SqlConnection conn = new SqlConnection(_connectString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT Name, StandardCost FROM SalesLT.Product", conn);
            //fill the dataset
            da.Fill(ds, "Products");
            //load data into grid
            dataGridView1.DataSource = ds.Tables["Products"];
            //use memory stream so we don't have to create temp files
			MemoryStream memStrm = new MemoryStream();
			StreamReader strmRead = new StreamReader(memStrm);
			StreamWriter strmWrite = new StreamWriter(memStrm);
			//dataGrid1.DataMember = "Authors";
			//write the xml from the dataset to the memory stream
			ds.WriteXml(strmWrite, XmlWriteMode.IgnoreSchema);
			memStrm.Seek(0, SeekOrigin.Begin);
			//read from the memory stream to a XmlDocument object
			doc.Load(strmRead);
			//get all of the products elements
            XmlNodeList nodeLst = doc.SelectNodes("//XMLProducts/Products");
            textBox1.Text = "";

            foreach (XmlNode node in nodeLst)
            {
                textBox1.Text += node.InnerXml + "\r\n";
            }
            
		}



		private void button3_Click(object sender, EventArgs e)
		{
            XmlDocument doc = new XmlDocument();
			//create a dataset
			DataSet ds = new DataSet("XMLProducts");
			//connect to the northwind database and 
			//select all of the rows from products table
			SqlConnection conn = new SqlConnection(_connectString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT Name, StandardCost FROM SalesLT.Product", conn);
			//fill the dataset
			da.Fill(ds, "Products");
			ds.WriteXml("sample.xml", XmlWriteMode.WriteSchema);
			//load data into grid
			dataGridView1.DataSource = ds.Tables[0];
			doc = new XmlDataDocument(ds);
			//get all of the products elements
			XmlNodeList nodeLst = doc.GetElementsByTagName("Products");
            textBox1.Text = "";
            foreach (XmlNode node in nodeLst)
            {
                textBox1.Text += node.InnerXml + "\r\n";
            }
		}


		private void button5_Click(object sender, EventArgs e)
		{
            XmlDocument doc = new XmlDocument();
			//create a dataset
			DataSet ds = new DataSet("XMLProducts");
			//connect to the northwind database and 
			//select all of the rows from products table and from suppliers table
			//make sure you connect string matches you server configuration

			SqlConnection conn = new SqlConnection(_connectString);

            SqlDataAdapter daProduct = new SqlDataAdapter("SELECT Name, StandardCost, ProductCategoryID FROM SalesLT.Product", conn);
            SqlDataAdapter daCategory = new SqlDataAdapter("SELECT ProductCategoryID, Name from SalesLT.ProductCategory", conn);
			//Fill DataSet from both SqlAdapters
			daProduct.Fill(ds, "Products");
			daCategory.Fill(ds, "Categories");
			//Add the relation
			ds.Relations.Add(ds.Tables["Categories"].Columns["ProductCategoryID"],
				ds.Tables["Products"].Columns["ProductCategoryID"]);
			//Write the Xml to a file so we can look at it later
			ds.WriteXml("Products.xml", XmlWriteMode.WriteSchema);
			//load data into grid
			dataGridView1.DataSource = ds.Tables[0];
			//create the XmlDataDocument
			doc = new XmlDataDocument(ds);
			//Select the productname elements and load them in the grid
			XmlNodeList nodeLst = doc.SelectNodes("//XMLProducts/Products");
            textBox1.Text = "";
            foreach (XmlNode node in nodeLst)
            {
                textBox1.Text += node.InnerXml + "\r\n";
            }
		}

		private void button7_Click(object sender, EventArgs e)
		{
			//create the DataSet
			DataSet ds = new DataSet("XMLProducts");
			//read in the xml document
			ds.ReadXml("products.xml");

			//load data into grid
			dataGridView1.DataSource = ds.Tables[0];
            textBox1.Text = "";
			foreach (DataTable dt in ds.Tables)
			{
                textBox1.Text += dt.TableName + "\r\n";
				foreach (DataColumn col in dt.Columns)
				{
					textBox1.Text += "\t" + col.ColumnName + " - " + col.DataType.FullName + "\r\n";
				}
			}
		
		}

	}
}