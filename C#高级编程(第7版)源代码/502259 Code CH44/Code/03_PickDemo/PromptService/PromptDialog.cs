using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PromptService
{
    public partial class PromptDialog : Form
    {
        public PromptDialog()
        {
            InitializeComponent();
        }

        public string PromptText
        {
            get { return this.promptText.Text; }
            set { this.promptText.Text = value; }
        }
    }
}
