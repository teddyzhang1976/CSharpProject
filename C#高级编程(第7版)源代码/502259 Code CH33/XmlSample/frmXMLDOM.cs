using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace XmlSample
{
  public partial class frmXMLDOM : Form
  {

    XmlDocument _doc = new XmlDocument();

    public frmXMLDOM()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //doc is declared at the module level
      //change path to math your path structure
      _doc.Load("books.xml");
      //get only the nodes that we want.
      XmlNodeList nodeLst = _doc.GetElementsByTagName("title");
      //iterate through the XmlNodeList
      textBox1.Text = "";
      foreach (XmlNode node in nodeLst)
      {
          textBox1.Text += node.OuterXml + "\r\n";
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      //doc is declared at the module level
      //change path to math your path structure
      _doc.Load("books.xml");
      //get onley the nodes that we want.
      XmlNodeList nodeLst = _doc.SelectNodes("/bookstore/book/title");

      textBox1.Text = "";
        //iterate through the XmlNodeList
      foreach (XmlNode node in nodeLst)
      {
          textBox1.Text += node.OuterXml + "\r\n";
      }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      //change path to match your structure
      _doc.Load("books.xml");
      //create a new 'book' element
      XmlElement newBook = _doc.CreateElement("book");
      //set some attributes
      newBook.SetAttribute("genre", "Mystery");
      newBook.SetAttribute("publicationdate", "2001");
      newBook.SetAttribute("ISBN", "123456789");
      //create a new 'title' element
      XmlElement newTitle = _doc.CreateElement("title");
      newTitle.InnerText = "Case of the Missing Cookie";
      newBook.AppendChild(newTitle);
      //create new author element
      XmlElement newAuthor = _doc.CreateElement("author");
      newBook.AppendChild(newAuthor);
      //create new name element
      XmlElement newName = _doc.CreateElement("name");
      newName.InnerText = "Cookie Monster";
      newAuthor.AppendChild(newName);
      //create new price element
      XmlElement newPrice = _doc.CreateElement("price");
      newPrice.InnerText = "9.95";
      newBook.AppendChild(newPrice);
      //add to the current document
      _doc.DocumentElement.AppendChild(newBook);
      //write out the doc to disk
      XmlTextWriter tr = new XmlTextWriter("booksEdit.xml", null);
      tr.Formatting = Formatting.Indented;
      _doc.WriteContentTo(tr);

      tr.Close();
      //load listBox1 with all of the titles, including new one
      XmlNodeList nodeLst = _doc.GetElementsByTagName("title");
      textBox1.Text = "";
      foreach (XmlNode node in nodeLst)
      {
          textBox1.Text += node.OuterXml + "\r\n";
      }
    }
  }
}