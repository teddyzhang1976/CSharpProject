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
    public partial class UpdateAccountPasswordDlg : Form
    {
        private PortfolioMainDlg portFolioMDlg;
        private UpdateAccountPasswordDlg()
        {
            InitializeComponent();
        }
        public UpdateAccountPasswordDlg(PortfolioMainDlg pfMDlg):this()
        {
            portFolioMDlg = pfMDlg;
        }

        private void updateAccountPasswordButton_Click(object sender, EventArgs e)
        {
            //confirm password for current account
            //
            if (!portFolioMDlg.portFolioMgr.currentAccount.loginAccount(oldPasswordTextBox.Text))
            {
                //pop up a message box informing user the password is not matched and should try again.
                MessageBox.Show("旧密码不对，重试吧");
                return;
            }

            ////////////////////////////////////////////
            //confirm password 
            if (("" == accountPasswordConfirmTextBox.Text) || ("" == accountPasswordTextBox.Text))
            {
                MessageBox.Show("用户密码不能为空");

            }
            if (accountPasswordConfirmTextBox.Text != accountPasswordTextBox.Text)
            {
                MessageBox.Show("前后两次密码不一致");
                return;
            }

            ///////////////////////////////////////////
            //update password to memory and storage
            //1. current am
            portFolioMDlg.portFolioMgr.currentAccount.accountPassword = accountPasswordTextBox.Text;
            //2. back to db
            portFolioMDlg.portFolioMgr.accountMgr.update(portFolioMDlg.portFolioMgr.currentAccount);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
