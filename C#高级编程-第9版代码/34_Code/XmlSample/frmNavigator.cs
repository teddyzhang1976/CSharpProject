using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace XmlSample
{
	public partial class frmNavigator : Form
	{
		public frmNavigator()
		{
			InitializeComponent();
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			//modify to match your path structure
			XPathDocument doc = new XPathDocument("books.xml");
			//create the XPath navigator
			XPathNavigator nav = ((IXPathNavigable)doc).CreateNavigator();
			//create the XPathNodeIterator of book nodes
			// that have genre attribute value of novel
			XPathNodeIterator iter = nav.Select("/bookstore/book[@genre='novel']");
            textBox1.Text = "";
			while (iter.MoveNext())
			{
				XPathNodeIterator newIter = iter.Current.SelectDescendants(XPathNodeType.Element, false);
                while (newIter.MoveNext())
                {
                    textBox1.Text += newIter.Current.Name + ": " + newIter.Current.Value + "\r\n";
                }
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//modify to match your path structure
			XPathDocument doc = new XPathDocument("books.xml");
			//create the XPath navigator
			XPathNavigator nav = ((IXPathNavigable)doc).CreateNavigator();
			//create the XPathNodeIterator of book nodes
			XPathNodeIterator iter = nav.Select("/bookstore/book");
            textBox1.Text = "";
			while (iter.MoveNext())
			{
				XPathNodeIterator newIter = iter.Current.SelectDescendants(XPathNodeType.Element, false);
				while (newIter.MoveNext())
                {
                    textBox1.Text += newIter.Current.Name + ": " + newIter.Current.Value + "\r\n";
                }
			}
            textBox1.Text += "=========================" + "\r\n";
            textBox1.Text += "Total Cost = " + nav.Evaluate("sum(/bookstore/book/price)");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load("books.xml");
			XPathNavigator nav = doc.CreateNavigator();

			if (nav.CanEdit)
			{
				XPathNodeIterator iter = nav.Select("/bookstore/book/price");
				while (iter.MoveNext())
				{
					iter.Current.InsertAfter("<disc>5</disc>");
				}

			}
			doc.Save("newbooks.xml");

		}

		
	}
}