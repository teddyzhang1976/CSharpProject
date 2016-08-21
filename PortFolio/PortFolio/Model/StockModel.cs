using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortFolio.Model
{
    //StockModel is used to descrip the whole position status in one account.
    class StockModel
    {
        public Account account
        {
            get;
            private set;
        }
        //every stock belongs to one account.
        public int code { get; set; }
        public String name { get; set; }
        public Double currentPrice { get; set; }

        List<StockPositionDataModel> floatPosition;       //浮动头寸列表
        List<StockPositionDataModel> liquidationPosition; //平仓头寸列表

        public StockModel(int code,String name,Account account)
        {
            this.code = code;
            this.name = name;
            this.account = account;
            floatPosition = new List<StockPositionDataModel>();
            liquidationPosition = new List<StockPositionDataModel>();
        }
        
    }
}
