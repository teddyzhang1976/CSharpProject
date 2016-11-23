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
using PortFolio.View.AccountManager;
using PortFolio.View.PositionManagr;
using PortFolio.Model;

namespace PortFolio
{
    public partial class PortfolioMainDlg : Form
    {
        public PortFolioManager portFolioMgr;
        public PortfolioMainDlg()
        {
            InitializeComponent();
        }
        public PortfolioMainDlg(PortFolioManager pfMgr)
            : this()
        {
            portFolioMgr = pfMgr;
        }

        private Boolean assertCurrentAccount()
        {
            if (portFolioMgr.currentAccount == null)
            {
                MessageBox.Show("当前账户为空或者未选择");
                return false;
            }
            return true;
        }
        private Boolean assertCurrentAccountIsLogined()
        {
            if (!assertCurrentAccount())
                return false;
            if (!portFolioMgr.currentAccount.isLogined)
            {
                MessageBox.Show("当前账户未登录，请选择登录");
                return false;
            }
            return true;
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AccountLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get current accountModel to see if the user has already logined.
            //send back a messagebox informing user it has been logined already and turn back. or....
            if (!assertCurrentAccount()) return;

            if (portFolioMgr.currentAccount.isLogined)
            {
                //has already logined, send a message informing user login is no longer needed.
                MessageBox.Show("已经登录了不需要重复登录");
                return;
            }

            AccountLoginDlg accountLoginDlg = new AccountLoginDlg(this);
            // set current account name in title
            accountLoginDlg.Text = portFolioMgr.currentAccount.accountName;

            //ask current accountModel if the user saved the password last time, if yes, load the password to passwordTextBox
            if (portFolioMgr.currentAccount.savedPassword != null)
            {
                accountLoginDlg.savePasswordCheckBox.Checked = true;
                accountLoginDlg.passwordTextBox.Text = portFolioMgr.currentAccount.savedPassword;
            }
            
            
            accountLoginDlg.Show();
        }

        private void CreateAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountEditDlg accountEditDlg = new AccountEditDlg(this);
            accountEditDlg.Text = "创建账户";

            //fill default value for every neccessary input
            accountEditDlg.initMoneyPooltextBox.Text = "200000";
            accountEditDlg.traderNameComboBox.SelectedIndex = 0;
            //accountEditDlg.traderNameTextBox.Text = "华泰证券";
            accountEditDlg.commissionRationTextBox.Text = "0.03";
            accountEditDlg.minCommissionTextBox.Text = "5";
            accountEditDlg.transferFeeRatioTextBox.Text = "0.00";
            accountEditDlg.minTransferFeeTextBox.Text = "0";
            accountEditDlg.taxRatioTextBox.Text = "0.01";
            accountEditDlg.delegateFeeRatioTextBox.Text = "0";

            //set invisible for some options such as account name,password
            accountEditDlg.Show();//in accountEditDlg's confirm button, update account model back to db.
        }

        private void UpdateAccountNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!assertCurrentAccount()) return;
            UpdateAccountNameDlg  upAccountNameDlg = new UpdateAccountNameDlg(this);
            upAccountNameDlg.oldNameLabel.Text = portFolioMgr.currentAccount.accountName;
            upAccountNameDlg.Show();
        }

        private void UpdateAccountPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
            UpdateAccountPasswordDlg updateAccountPassword = new UpdateAccountPasswordDlg(this);
            updateAccountPassword.Text = "修改账户密码-" + portFolioMgr.currentAccount.accountName;
            updateAccountPassword.Show();
        }

        private void AccountConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //see if current is selected and logined.
            if (!assertCurrentAccount())
                return;
            if (!assertCurrentAccountIsLogined())
                return;

            //get current account's object.
            AccountEditDlg accountEditDlg = new AccountEditDlg(this);
            accountEditDlg.Text = "账户参数设置";
            //fill the accountEditDlg with account object.
            accountEditDlg.accountNameTextBox.Text = portFolioMgr.currentAccount.accountName;
            accountEditDlg.accountNameTextBox.Enabled = false;

            accountEditDlg.commissionRationTextBox.Text = portFolioMgr.currentAccount.commissionRatio.ToString();
            accountEditDlg.minCommissionTextBox.Text = portFolioMgr.currentAccount.minCommission.ToString();
            accountEditDlg.transferFeeRatioTextBox.Text = portFolioMgr.currentAccount.transferFeeRatio.ToString();
            accountEditDlg.minTransferFeeTextBox.Text = portFolioMgr.currentAccount.minTransferFee.ToString();
            accountEditDlg.taxRatioTextBox.Text = portFolioMgr.currentAccount.taxRatio.ToString();
            accountEditDlg.delegateFeeRatioTextBox.Text = portFolioMgr.currentAccount.delegateFeeRatio.ToString();
            accountEditDlg.accountMemoRichTextBox.Text = portFolioMgr.currentAccount.accountMemo;

            accountEditDlg.accountPasswordTextBox.Text = portFolioMgr.currentAccount.accountPassword.ToString();
            accountEditDlg.accountPasswordConfirmTextBox.Text = portFolioMgr.currentAccount.accountPassword.ToString();
            accountEditDlg.initMoneyPooltextBox.Text = portFolioMgr.currentAccount.money.ToString();
            accountEditDlg.traderNameComboBox.Text = portFolioMgr.currentAccount.traderName;

            accountEditDlg.accountPasswordTextBox.Enabled = false;
            accountEditDlg.accountPasswordConfirmTextBox.Enabled = false;
            accountEditDlg.accountMemoRichTextBox.Enabled = false;
            accountEditDlg.initMoneyPooltextBox.Enabled = false; 

            accountEditDlg.Show();//in accountEditDlg's confirm button, update account model back to db.
        }

        private void GeneralJournalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
            new GeneralJournalDlg(this).Show();
        }

        private void PositionJournalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
            new PositionJournalDlg(this).Show();
        }

        private void AccountDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
            //get current AccountModel
            //new AccountEditDlg
            AccountEditDlg accountEditDlg = new AccountEditDlg(this);
            //fill above dlg with AccountModel's properties
            accountEditDlg.Show();
        }

        private void BuyOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
            //get current stock and account,this pointer includs these two properties.
            PositionTradeDlg positionTradeDlg = new PositionTradeDlg(this);
            //set default trading direction to buyopen and disablle it's selectable property
            positionTradeDlg.tradingDirectionComboBox.SelectedIndex = 0;//0 duokai
            positionTradeDlg.tradingDirectionComboBox.Enabled = false;
            //generate an event ID
            //new event model and fill it with related information.
            positionTradeDlg.Show(); 

        }

        private void SoldOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
            //get current stock and account,this pointer includs these two properties.
            PositionTradeDlg positionTradeDlg = new PositionTradeDlg(this);
            //set default trading direction to buyopen and disablle it's selectable property
            positionTradeDlg.tradingDirectionComboBox.SelectedIndex = 1;//0 duokai
            positionTradeDlg.tradingDirectionComboBox.Enabled = false;
            //generate an event ID
            //new event model and fill it with related information.
            positionTradeDlg.Show(); 
        }

        private void BuyCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
            //get current stock and account,this pointer includs these two properties.
            PositionTradeDlg positionTradeDlg = new PositionTradeDlg(this);
            //set default trading direction to buyopen and disablle it's selectable property
            positionTradeDlg.tradingDirectionComboBox.SelectedIndex = 2;//0 duokai
            positionTradeDlg.tradingDirectionComboBox.Enabled = false;
            //generate an event ID
            //new event model and fill it with related information.
            positionTradeDlg.Show(); 
        }

        private void SoldCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
            //get current stock and account,this pointer includs these two properties.
            PositionTradeDlg positionTradeDlg = new PositionTradeDlg(this);
            //set default trading direction to buyopen and disablle it's selectable property
            positionTradeDlg.tradingDirectionComboBox.SelectedIndex = 3;//0 duokai
            positionTradeDlg.tradingDirectionComboBox.Enabled = false;
            //generate an event ID
            //new event model and fill it with related information.
            positionTradeDlg.Show(); 
        }

        private void MoveInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
            PositionMoveInOutDlg positionMoveInOutDlg = new PositionMoveInOutDlg(this);
            positionMoveInOutDlg.tradingDirectionComboBox.SelectedIndex = 0;//0 means moveIn 1 means moveOut
            positionMoveInOutDlg.tradingDirectionComboBox.Enabled = false;
            positionMoveInOutDlg.Show();
        }

        private void MoveOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
            PositionMoveInOutDlg positionMoveInOutDlg = new PositionMoveInOutDlg(this);
            positionMoveInOutDlg.tradingDirectionComboBox.SelectedIndex = 1;//0 means moveIn 1 means moveOut
            positionMoveInOutDlg.tradingDirectionComboBox.Enabled = false;
            positionMoveInOutDlg.Show();
        }

        private void MoveInMoneyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
            MoveInOutMoneyDlg moneyMoveInOutDlg = new MoveInOutMoneyDlg(this);
            moneyMoveInOutDlg.tradingDirectionComboBox.SelectedIndex = 0;//0 means move in money
            moneyMoveInOutDlg.tradingDirectionComboBox.Enabled = false;
            moneyMoveInOutDlg.Show();
        }

        private void MoveOutMoneyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
            MoveInOutMoneyDlg moneyMoveInOutDlg = new MoveInOutMoneyDlg(this);
            moneyMoveInOutDlg.tradingDirectionComboBox.SelectedIndex = 1;//0 means move in money
            moneyMoveInOutDlg.tradingDirectionComboBox.Enabled = false;
            moneyMoveInOutDlg.Show();
        }

        private void MoneyHongChongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
            MoveInOutMoneyDlg moneyMoveInOutDlg = new MoveInOutMoneyDlg(this);
            moneyMoveInOutDlg.tradingDirectionComboBox.SelectedIndex = 2;//0 means move in money
            moneyMoveInOutDlg.tradingDirectionComboBox.Enabled = false;
            moneyMoveInOutDlg.Show();
        }

        private void MoneyLanbuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
            MoveInOutMoneyDlg moneyMoveInOutDlg = new MoveInOutMoneyDlg(this);
            moneyMoveInOutDlg.tradingDirectionComboBox.SelectedIndex = 3;//0 means move in money
            moneyMoveInOutDlg.tradingDirectionComboBox.Enabled = false;
            moneyMoveInOutDlg.Show();
        }

        private void DeleteEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!assertCurrentAccount()) return;
           // portFolioMgr.currentAccount = null;
            portFolioMgr.currentAccount.isLogined = false;
            //informing related operation connected to currentAccount. the account treeView should be connected to this property as a observor
        }
        public void deleteAccountListBoxItem(AccountModel am)
        {
            if(accountListBox.Items.Count>0)
            accountListBox.Items.Remove(am.accountName.ToString());
        }
        public void loadAccountListBox()
        {
            if ((null == portFolioMgr.accountModelList) || (portFolioMgr.accountModelList.Count == 0))
                return;
            accountListBox.BeginUpdate();
            foreach (AccountModel am in portFolioMgr.accountModelList)
            {
                addAccountListBoxItem(am);
            }
            accountListBox.EndUpdate();
        }

        private void DeleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //see if current is selected and logined.
            if(!assertCurrentAccount())
                return;
            if(!assertCurrentAccountIsLogined())
                return;

            //call back to portFolioMgr's delte method
            portFolioMgr.deleteCurrentAccount();
        }

        private void accountListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            
        }

        private void accountListView_ItemActivate(object sender, EventArgs e)
        {
          //  MessageBox.Show("选中我了");
            AccountLoginToolStripMenuItem_Click(null, null);
        }

        public void addAccountListBoxItem(AccountModel am)
        {
            accountListBox.Items.Add(am.accountName);
        }

        private void accountListBox_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("accountListBox_Click");
             portFolioMgr.setCurrentAccount(accountListBox.SelectedItem.ToString());
        }

        private void accountListBox_DoubleClick(object sender, EventArgs e)
        {
            AccountLoginToolStripMenuItem_Click(null, null);
        }

    }
}
