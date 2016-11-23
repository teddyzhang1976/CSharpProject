using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortFolio.Control.interfaces;
using PortFolio.Control;

namespace PortFolio.Model
{
    //StockModel is used to descrip the whole position status in one account.
    public class StockModel
    {
        public int accountID { get; set; }
        public int stockCode { get; set; }
        public String stockName { get; set; }
        public Double currentPrice { get; set; }

   //serialize above properties for storage manage use  
        
        
        private List<PositionModel> floatPosition;       //浮动头寸列表
        private List<PositionModel> liquidationPosition; //平仓头寸列表

        public IPositionManager positionMgr { get; set; }


        public AccountModel account
        {
            get;
            private set;
        }
        //every stock belongs to one account.
        public StockModel()
        {
            //for loading use
            positionMgr = GeneralManagerFactory.createPositionManager();
        }
        public StockModel(int code,String name,AccountModel account):this()
        {
            this.stockCode = code;
            this.stockName = name;
            this.account = account;
        }

        //below operations are calculated and for view layer component use.

        public Boolean hasFloatPosition()
        {
            if ((null == floatPosition)||( 0 == floatPosition.Count))
                return false;
            return true;
        }

    }
}
