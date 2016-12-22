using System;
using System.Windows.Forms;

namespace Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Text = webBrowser1.DocumentTitle.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                webBrowser1.Navigate(textBox1.Text);
            }
        }

        private void webBrowser1_Navigated(object sender,
           WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonBack.Enabled = false;
            buttonForward.Enabled = false;
            buttonStop.Enabled = false;

            this.webBrowser1.CanGoBackChanged +=new EventHandler(webBrowser1_CanGoBackChanged);
            this.webBrowser1.CanGoForwardChanged +=new EventHandler(webBrowser1_CanGoForwardChanged);
            this.webBrowser1.DocumentTitleChanged +=new EventHandler(webBrowser1_DocumentTitleChanged);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
            textBox1.Text = webBrowser1.Url.ToString();
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
            textBox1.Text = webBrowser1.Url.ToString();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
            textBox1.Text = webBrowser1.Url.ToString();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
        }

        private void webBrowser1_CanGoBackChanged(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                buttonBack.Enabled = true;
            }
            else
            {
                buttonBack.Enabled = false;
            }
        }

        private void webBrowser1_CanGoForwardChanged(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                buttonForward.Enabled = true;
            }
            else
            {
                buttonForward.Enabled = false;
            }
        }

        private void webBrowser1_Navigating(object sender,
           WebBrowserNavigatingEventArgs e)
        {
            buttonStop.Enabled = true;
        }

        private void webBrowser1_DocumentCompleted(object sender,
           WebBrowserDocumentCompletedEventArgs e)
        {
            buttonStop.Enabled = false;
            textBox2.Text = webBrowser1.DocumentText;
        }

    }
}