#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;

#endregion

namespace XMLSample
{
  partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      richTextBox1.Clear();
      XmlReader rdr = XmlReader.Create("books.xml");
      while (rdr.Read())
      {
        richTextBox1.AppendText(rdr.NodeType.ToString() + "\r\n");
      }

    }

    private void button2_Click(object sender, EventArgs e)
    {
      richTextBox1.Clear();
      XmlReader rdr = XmlReader.Create("books.xml");
      while (rdr.Read())
      {
        if (rdr.NodeType == XmlNodeType.Element)
          richTextBox1.AppendText(rdr.Name + "\r\n");
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      richTextBox1.Clear();
      XmlReader rdr = XmlReader.Create("books.xml");
      while (rdr.Read())
      {
        if (rdr.NodeType == XmlNodeType.Text)
          richTextBox1.AppendText(rdr.Value + "\r\n");
      }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      richTextBox1.Clear();
      XmlCSVReader rdr = new XmlCSVReader("addresses.csv");
      while (rdr.Read())
      {
        if (rdr.NodeType == XmlNodeType.Text)
          richTextBox1.AppendText(rdr.Value + "\r\n");
      }
    }

    private void button5_Click(object sender, EventArgs e)
    {
     richTextBox1.Clear();
      XmlReader rdr = XmlReader.Create("books.xml");
      while (rdr.Read())
      {
        if (rdr.NodeType == XmlNodeType.Element)
        {
          if (rdr.Name == "price")
          {
						decimal price = rdr.ReadElementContentAsDecimal();
            richTextBox1.AppendText("Current Price = " + price + "\r\n");
            price += price * (decimal).25;
            richTextBox1.AppendText("New Price = " + price + "\r\n\r\n");
          }
          else if(rdr.Name== "title")
            richTextBox1.AppendText(rdr.ReadElementContentAsString() + "\r\n");
        }
      }

    }

    private void button6_Click(object sender, EventArgs e)
    {
      richTextBox1.Clear();
			XmlReader rdr = XmlReader.Create("books.xml");
      while (!rdr.EOF)
      {
        //if we hit an element type, try and load it in the listbox
        if (rdr.MoveToContent() == XmlNodeType.Element && rdr.Name == "title")
        {
          richTextBox1.AppendText(rdr.ReadElementString() + "\r\n");
        }
        else
        {
          //otherwise move on
          rdr.Read();
        }
      }
    }

    
private void button7_Click(object sender, EventArgs e)
{
  richTextBox1.Clear();
  XmlReader tr = XmlReader.Create("books.xml");
  //Read in node at a time        
  while (tr.Read())
  {
    //check to see if it's a NodeType element
    if (tr.NodeType == XmlNodeType.Element)
    {
      //if it's an element, then let's look at the attributes.
      for (int i = 0; i < tr.AttributeCount; i++)
      {
        richTextBox1.AppendText(tr.GetAttribute(i) + "\r\n");
      }
    }
  }
}

private void button8_Click(object sender, EventArgs e)
{
  richTextBox1.Clear();

  XmlReaderSettings settings = new XmlReaderSettings();
  settings.Schemas.Add(null, "books.xsd");
	settings.ValidationType = ValidationType.Schema;
  settings.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(settings_ValidationEventHandler);
  XmlReader rdr = XmlReader.Create("books.xml", settings);
  while (rdr.Read())
  {
    if (rdr.NodeType == XmlNodeType.Text)
      richTextBox1.AppendText(rdr.Value + "\r\n");
  }
}

void settings_ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
{
  MessageBox.Show(e.Message);
}

private void button9_Click(object sender, EventArgs e)
{
  XmlWriterSettings settings = new XmlWriterSettings();
  settings.Indent = true;
  settings.NewLineOnAttributes = true;
  XmlWriter writer = XmlWriter.Create("newbook.xml", settings);
  writer.WriteStartDocument();
  //Start creating elements and attributes
  writer.WriteStartElement("book");
  writer.WriteAttributeString("genre", "Mystery");
  writer.WriteAttributeString("publicationdate", "2001");
  writer.WriteAttributeString("ISBN", "123456789");
  writer.WriteElementString("title", "Case of the Missing Cookie");
  writer.WriteStartElement("author");
  writer.WriteElementString("name", "Cookie Monster");
  writer.WriteEndElement();
  writer.WriteElementString("price", "9.99");
  writer.WriteEndElement();
  writer.WriteEndDocument();
  //clean up
  writer.Flush();
  writer.Close();
}
  }
}