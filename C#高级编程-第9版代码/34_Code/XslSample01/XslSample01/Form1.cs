#region Using directives

using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

#endregion

namespace XslSample01
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load("books.xsl");
            trans.Transform("books.xml", "out.html");
            webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "out.html");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load("booksdisc.xsl");
            trans.Transform("books.xml", "disc.xml");
            webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "disc.xml");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //new XPathDocument
            XPathDocument doc = new XPathDocument("books.xml");
            //new XslTransform
            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load("booksarg.xsl");
            //new XmlTextWriter since we are creating a new xml document
            XmlWriter xw = new XmlTextWriter("argSample.xml", null);
            //create the XslArgumentList and new BookUtils object
            XsltArgumentList argBook = new XsltArgumentList();
            BookUtils bu = new BookUtils();
            //this tells the argumentlist about BookUtils
            argBook.AddExtensionObject("urn:XslSample01", bu);
            //new XPathNavigator
            XPathNavigator nav = doc.CreateNavigator();
            //do the transform
            trans.Transform(nav, argBook, xw);
            xw.Close();
            webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "argSample.xml");
        }

    }
}