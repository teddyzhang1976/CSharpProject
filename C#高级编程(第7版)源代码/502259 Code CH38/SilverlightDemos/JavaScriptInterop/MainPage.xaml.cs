using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;

namespace JavaScriptInterop
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            HtmlDocument doc = HtmlPage.Document;
            HtmlElement element = doc.GetElementById("button1");
            element.AttachEvent("onclick", OnHtmlButtonClick);

            HtmlPage.RegisterScriptableObject("ScriptKey", this);
        }

        private void OnChangeHtml(object sender, RoutedEventArgs e)
        {
            HtmlDocument doc = HtmlPage.Document;
            HtmlElement element = doc.GetElementById("button1");
            element.SetAttribute("value", text1.Text);
        }

        private void OnHtmlButtonClick(object sender, HtmlEventArgs e)
        {
            text2.Text = "HTML button onclick fired";
        }

        [ScriptableMember]
        public string ToUpper(string s)
        {
            return s.ToUpper();
        }
    }
}
