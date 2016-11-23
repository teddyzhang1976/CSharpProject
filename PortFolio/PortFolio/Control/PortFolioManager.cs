using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PortFolio.Control.interfaces;
using PortFolio.Model;
using PortFolio.View;
using PortFolio.View.AccountManager;

namespace PortFolio.Control
{
    /// <summary>
    /// actually portFolioManager is an accountManager holder to implement all actually account manager including it's UI. 
    /// it is the app's calling center
    /// </summary>
    public class PortFolioManager
    {
        public IAccountManager accountMgr { get; set; }
        public IEventManager eventMgr { get; set; }
        public AccountModel currentAccount { get; set; }

        public List<AccountModel> accountModelList;
        public PositionMonitorDlg positionTradingDlg;//keep
        public PortfolioMainDlg portFolioMainDlg;//keep
       // public AccountEditDlg accountEditDlg;

        private static PortFolioManager instance;

        //load tables from storage to create AccountManager,StockManager,PositionManager which will create AccountModel,StockModel,PositionModel arrays
        private void portFolioInit()
        {
            Console.WriteLine("PortFolioManager.portFolioInit");
            accountMgr = GeneralManagerFactory.createAccountManager();
            eventMgr = GeneralManagerFactory.createEventManager();
            portFolioMainDlg = new PortfolioMainDlg(this);
            positionTradingDlg = new PositionMonitorDlg(this);

            if ((null == accountMgr)||(null == eventMgr))
            {
                Console.WriteLine("accountMgr or eventMgr create fail!");
                throw new Exception();
            }
            accountModelList = accountMgr.load();
        }
        private PortFolioManager()
        {
            //loader
            portFolioInit();
        }

        public static PortFolioManager singleInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PortFolioManager();
                }
                return instance;
            }
        }

        //for starter use
        public Form selectMainDlg()
        {
            //return new PositionTradingDlg(this);
            return portFolioMainDlg;
        }

        public void createAccount(AccountModel am)
        {
            AccountModel containAm = selectAccount(am.accountName);
            if (containAm != null) //really update to list and db
            {
                containAm.copyFrom(am); //update memory data in list .
                accountMgr.update(am); //update back to db.
            }
            else
            {
                if (null == accountModelList)
                    accountModelList = new List<AccountModel>();
                
                accountModelList.Add(am);//update to memory list
                currentAccount = am;
                portFolioMainDlg.addAccountListBoxItem(am);//update to accountListView;
              //  portFolioMainDlg.addAccountListBoxItem(am);
            }
            accountMgr.add(am);//update to db;
        }
        public void updateAccount(AccountModel am)
        {
            AccountModel containAm = selectAccount(am.accountName);
            if (containAm != null) //really update to list and db
            {
                if(MessageBox.Show("该用户名已经存在，是否更新参数？","是否更新",MessageBoxButtons.YesNo)==DialogResult.Yes){
                    containAm.copyFrom(am); //update memory data in list .
                    accountMgr.update(am); //update back to db.
                }
            }
            else
                createAccount(am);
        }
        public AccountModel selectAccount(String accountName)
        {
            if((accountModelList == null)||(0==accountModelList.Count)){
                return null;
            }
            foreach (AccountModel am in accountModelList)
            {
                if (am.accountName == accountName)
                    return am;
            }
            return null;
            
        }
        public void deleteAccount(AccountModel am)
        {
            //delete list view fist
            portFolioMainDlg.deleteAccountListBoxItem(am);
            //dellte in list
            accountModelList.Remove(am);
            //update to db            
            accountMgr.delete(am.accountName);//update to db
            //update list view
           // portFolioMainDlg.accountListView.Items.Remove(portFolioMainDlg.accountListView.Items.Find(am.accountName, false));
        }
        public void deleteCurrentAccount()
        {
            if (null == currentAccount)
            {
                MessageBox.Show("当前没有选定任何账户，无法删除");
                return;
            }
            //delete current account first
            deleteAccount(currentAccount);
            //set curent account to null
            currentAccount = null;
        }
        public void setCurrentAccount(String acName)
        {
            AccountModel am =selectAccount(acName);
            if (null != am)
            {
                currentAccount = am;
            }
        }
    }
}
