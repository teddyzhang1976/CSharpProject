using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortFolio.Control.interfaces;
using PortFolio.Control;

namespace PortFolio.Model
{
    /// <summary>
    /// 负责下层stockList的存储管理（增删改查）使用成员stockMgr，另外还要负责account相关的计算统计操作，参考通达信的设计看看还有什么
    /// 例如：
    ///  一共拥有多少股票，
    ///  多少未完结股票，
    ///  总投入资金
    ///  资金划出
    ///  资金划入
    ///  红冲
    ///  蓝补
    ///  操作事件管理（似乎还需要一张表,一个账户事件管理器，accountEvent.table 和 accountEventMgr）
    /// </summary>
    public class AccountModel
    {
      //  public int accountID { get; set; } //when update accountName, this is not needed.
        public String accountName { get; set; }//can be and shold be the primary key.
        public String accountPassword { get; set; }
        public Double money { get; set; }
        public String traderName { get; set; }
        public double commissionRatio { get; set; }
        public double minCommission { get; set; }
        public double transferFeeRatio { get; set; }
        public double minTransferFee { get; set; }
        public double taxRatio { get; set; }
        public double delegateFeeRatio { get; set; }
        public String accountMemo { get; set; }
        /// <summary>
        /// above properties are the propertype of account table which will be stored in permanent storage.
        /// </summary>

        public Boolean isLogined { get; set; }
        public String savedPassword { get; set; }
        public IStockManager stockMgr { get; set; } //管理stockmodel和存储介质的交互，stockMgr将stock作为一个整体进行操作，和stock自身的操作不一样，所以分离出来。

        private List<StockModel> stockList; // 交易中或交易过的股票集合
        private StockModel currentStockModel; //the current selected stock

        public AccountModel()
        {
            stockMgr = GeneralManagerFactory.createStockManager();
        }
        public void loadStocks(){
            stockList = stockMgr.load(accountName);
        }

        //below operations are calculated and for view layer component use.
        
        //how many floating stocks does this account has?
        public int getFloatStocksCount()
        {
            int ret = 0;
            if((null == stockList)||( 0 == stockList.Count))
                return ret;
            foreach(StockModel sm in stockList){
                if(sm.hasFloatPosition())
                    ret++;
            }
            return ret;
        }

        //how many stocks does this account has?
        public int getStocksCount(){
            if(null==stockList)
                return 0;
            return stockList.Count;
        }

        public Boolean loginAccount(String passwd)
        {
            //
            return accountPassword == passwd;

        }

        public void copyFrom(AccountModel am)
        {
         //   accountID = am.accountID;
            accountName = am.accountName;
            accountPassword = am.accountPassword;
            money = am.money;
            traderName = am.traderName;
            commissionRatio = am.commissionRatio;
            minCommission = am.minCommission;
            transferFeeRatio = am.transferFeeRatio;
            minTransferFee = am.minTransferFee;
            taxRatio = am.taxRatio;
            delegateFeeRatio = am.delegateFeeRatio;
            accountMemo = am.accountMemo;
        }
    }
}
