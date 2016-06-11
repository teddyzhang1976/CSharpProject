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
	public partial class Form1 : Form
	{
		string _connectString = "data source=D8746\\sqlexpress;initial catalog=Northwind;integrated security=SSPI;";
		private XmlDocument doc = new XmlDocument();

		public Form1()
		{
			InitializeComponent();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			listBox1.SelectedIndexChanged += new EventHandler(example1_SelectedIndexChanged);

			//create a dataset
			DataSet ds = new DataSet("XMLAuthors");
			//connect to the northwind database and 
			//select all of the rows from products table

			SqlConnection conn = new SqlConnection(_connectString);


			SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM authors", conn);

			//use memory stream so we don't have to create temp files

			MemoryStream memStrm = new MemoryStream();
			StreamReader strmRead = new StreamReader(memStrm);
			StreamWriter strmWrite = new StreamWriter(memStrm);
			//fill the dataset
			da.Fill(ds, "Authors");
			//load data into grid
			dataGridView1.DataSource = ds.Tables[0];
			//dataGrid1.DataMember = "Authors";
			//write the xml from the dataset to the memory stream
			ds.WriteXml(strmWrite, XmlWriteMode.IgnoreSchema);
			memStrm.Seek(0, SeekOrigin.Begin);
			//read from the memory stream to a XmlDocument object
			doc.Load(strmRead);
			//get all of the products elements
			XmlNodeList nodeLst = doc.SelectNodes("//au_lname");
			//load them into the list box
			foreach (XmlNode nd in nodeLst)
				listBox1.Items.Add(nd.InnerText);
		}

		void example1_SelectedIndexChanged(object sender, EventArgs e)
		{
			//when you click on the listbox.
			//a message box with the XML of the selected node
			string srch = "XMLAuthors/Authors[au_lname=" + '"' + listBox1.SelectedItem.ToString() + '"' + "]";
			XmlNode foundNode = doc.SelectSingleNode(srch);
			if (foundNode != null)
				MessageBox.Show(foundNode.OuterXml);
			else
				MessageBox.Show("Not found");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			listBox1.SelectedIndexChanged -= new EventHandler(example1_SelectedIndexChanged);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			listBox1.SelectedIndexChanged += new EventHandler(example1_SelectedIndexChanged);

			//create a dataset
			DataSet ds = new DataSet("XMLAuthors");
			//connect to the northwind database and 
			//select all of the rows from products table
			SqlConnection conn = new SqlConnection(_connectString);

			SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM authors", conn);

			//fill the dataset
			da.Fill(ds, "Authors");
			ds.WriteXml("sample.xml", XmlWriteMode.WriteSchema);
			//load data into grid
			dataGridView1.DataSource = ds.Tables[0];
			doc = new XmlDataDocument(ds);
			//get all of the products elements
			XmlNodeList nodeLst = doc.GetElementsByTagName("au_lname");
			//load them into the list box
			for (int ctr = 0; ctr < nodeLst.Count; ctr++)
				//foreach(XmlNode node in nodeLst)
				// listBox1.Items.Add(node.InnerText);
				listBox1.Items.Add(nodeLst[ctr].InnerText);
		}

		
		private void button4_Click(object sender, EventArgs e)
		{
			listBox1.SelectedIndexChanged -= new EventHandler(example1_SelectedIndexChanged);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			listBox1.SelectedIndexChanged += new EventHandler(example1_SelectedIndexChanged);

			//create a dataset
			DataSet ds = new DataSet("XMLAuthors");
			//connect to the northwind database and 
			//select all of the rows from products table and from suppliers table
			//make sure you connect string matches you server configuration

			SqlConnection conn = new SqlConnection(_connectString);

			SqlDataAdapter daProd = new SqlDataAdapter("SELECT * FROM authors", conn);
			SqlDataAdapter daSup = new SqlDataAdapter("SELECT * FROM titleauthor", conn);
			//Fill DataSet from both SqlAdapters
			daProd.Fill(ds, "Authors");
			daSup.Fill(ds, "Titles");
			//Add the relation
			ds.Relations.Add(ds.Tables["Authors"].Columns["au_id"],
				ds.Tables["Titles"].Columns["au_id"]);
			//Write the Xml to a file so we can look at it later
			ds.WriteXml("AuthorTitle.xml", XmlWriteMode.WriteSchema);
			//load data into grid
			dataGridView1.DataSource = ds.Tables[0];
			//create the XmlDataDocument
			doc = new XmlDataDocument(ds);
			//Select the productname elements and load them in the grid
			XmlNodeList nodeLst = doc.SelectNodes("//au_lname");

			foreach (XmlNode nd in nodeLst)
				listBox1.Items.Add(nd.InnerXml);
    
		}

		private void button6_Click(object sender, EventArgs e)
		{
			listBox1.SelectedIndexChanged -= new EventHandler(example1_SelectedIndexChanged);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			//create the DataSet
			DataSet ds = new DataSet("XMLAuthors");
			//read in the xml document
			ds.ReadXml("AuthorTitle.xml");

			//load data into grid
			dataGridView1.DataSource = ds.Tables[0];
			//load the listbox with table, column and datatype info
			foreach (DataTable dt in ds.Tables)
			{
				listBox1.Items.Add(dt.TableName);
				foreach (DataColumn col in dt.Columns)
				{
					listBox1.Items.Add
						('\t' + col.ColumnName + " - " + col.DataType.FullName);
				}
			}
		
		}

	}
}