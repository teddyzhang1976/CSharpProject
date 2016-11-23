using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PortFolio.Control;
using PortFolio.Model;

namespace PortFolio.View.AccountManager
{
    public partial class AccountEditDlg : Form
    {
        private PortfolioMainDlg portFolioMDlg;

        //private static AccountEditDlg instance;
        private AccountEditDlg()
        {
            InitializeComponent();
           // this.ControlBox = false; 
        }

        public AccountEditDlg(PortfolioMainDlg pfMDlg)
            : this()
        {
            portFolioMDlg = pfMDlg;
        }
        /*
        public static AccountEditDlg singleInstance
        {
            get
            {
                if (instance == null)
                    instance = new AccountEditDlg();
                return instance;
            }
        }
        */

        /*public static AccountEditDlg getInstance(PortFolioManager pfMgr)
        {
            if (instance == null)
            {
                instance = new AccountEditDlg();
                instance.portFolioMgr = pfMgr;
            }
            return instance;
        }
        */
        private void numericValidateKeyPress(object sender, KeyPressEventArgs e){
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
            {
                e.Handled = true;
            }
            TextBox textBox1 = (TextBox)sender;
            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (textBox1.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else                                             //处理不规则的小数点
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textBox1.Text, out oldf);
                    b2 = float.TryParse(textBox1.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ("" == accountNameTextBox.Text)
            {
                MessageBox.Show("账户名不能为空");
                return;
            }
            if (("" == accountPasswordConfirmTextBox.Text) || ("" == accountPasswordTextBox.Text))
            {
                MessageBox.Show("用户密码不能为空");

            }
            if (accountPasswordConfirmTextBox.Text != accountPasswordTextBox.Text)
            {
                MessageBox.Show("前后两次密码不一致");
                return;
            }

           


            //create accountModel
            AccountModel newAccount = new AccountModel();
            //fill it with dlg's input
            newAccount.accountName = accountNameTextBox.Text;
            newAccount.accountPassword = accountPasswordTextBox.Text;
            newAccount.money = Double.Parse(initMoneyPooltextBox.Text.ToString());
            newAccount.accountMemo = accountMemoRichTextBox.Text;
            newAccount.traderName = traderNameComboBox.Text;


            newAccount.commissionRatio = Double.Parse(commissionRationTextBox.Text.ToString());
            newAccount.transferFeeRatio = Double.Parse(transferFeeRatioTextBox.Text.ToString());
            newAccount.minCommission = Double.Parse(minCommissionTextBox.Text.ToString());
            newAccount.minTransferFee = Double.Parse(minTransferFeeTextBox.Text.ToString());
            newAccount.taxRatio = Double.Parse(taxRatioTextBox.Text.ToString());
            newAccount.delegateFeeRatio = Double.Parse(delegateFeeRatioTextBox.Text.ToString());

            newAccount.isLogined = true;

            portFolioMDlg.portFolioMgr.updateAccount(newAccount); //remember change back to db at the same time.

            Close();
        }

        private void accountNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetterOrDigit(e.KeyChar)) && ((int)e.KeyChar != 8) && ((int)e.KeyChar != 46))
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
                
        }

    }
}
