using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace XmlSample
{
  public partial class frmDiffgram : Form
  {
    public frmDiffgram()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string connectString = "Server=.\\SQLExpress;Database=adventureworkslt;Trusted_Connection=Yes";
      //create a dataset
			DataSet ds = new DataSet("XMLProducts");
			//connect to the pubs database and 
			//select all of the rows from products table

			SqlConnection conn = new SqlConnection(connectString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT Name, StandardCost FROM SalesLT.Product", conn);
			da.Fill(ds, "Products");

      ds.Tables[0].Rows[0]["Name"] = "NewName";
      DataRow dr = ds.Tables[0].NewRow();
      dr["Name"] = "Unicycle";
      dr["StandardCost"] = "45.00";
      
      ds.Tables[0].Rows.Add(dr);
      ds.WriteXmlSchema("products.xdr");
      ds.WriteXml("proddiff.xml", XmlWriteMode.DiffGram);

      webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "/proddiff.xml");
      
      
      //load data into grid
			dataGridView1.DataSource = ds.Tables[0];
      
    }
  }
}