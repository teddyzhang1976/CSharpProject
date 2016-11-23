using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortFolio.View.AccountManager
{
    public partial class AccountLoginDlg : Form
    {
        private PortfolioMainDlg portFolioMDlg;
        private AccountLoginDlg()
        {
            InitializeComponent();
        }

        public AccountLoginDlg(PortfolioMainDlg pfMDlg):this()
        {
            portFolioMDlg = pfMDlg;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
           
            if (!savePasswordCheckBox.Checked)
                portFolioMDlg.portFolioMgr.currentAccount.savedPassword = null;
            else
                portFolioMDlg.portFolioMgr.currentAccount.savedPassword = passwordTextBox.Text;

            if (!portFolioMDlg.portFolioMgr.currentAccount.loginAccount(passwordTextBox.Text))
            {
                //pop up a message box informing user the password is not matched and should try again.
                MessageBox.Show("密码不对，重试吧");
                return;
            }
            //login success, set account opened status and close this dlg.
            portFolioMDlg.portFolioMgr.currentAccount.isLogined = true;
            //maybe need to update related treeView icon for current Account as unfolded
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close(); // 88
        }
    }
}
