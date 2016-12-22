using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XmlSample
{
	public partial class frmMain : Form
	{
		Form _frm;

		public frmMain()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (_frm != null)
				_frm.Dispose();

			_frm = new frmADOXML();
			_frm.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (_frm != null)
				_frm.Dispose();

			_frm = new frmXMLDOM();
			_frm.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (_frm != null)
				_frm.Dispose();

			_frm = new frmNavigator();
			_frm.Show();
		}

    private void button4_Click(object sender, EventArgs e)
    {
      if (_frm != null)
        _frm.Dispose();

      _frm = new frmSerial();
      _frm.Show();
    }

    private void button5_Click(object sender, EventArgs e)
    {
      if (_frm != null)
        _frm.Dispose();

      _frm = new frmDiffgram();
      _frm.Show();
    }

	}
}