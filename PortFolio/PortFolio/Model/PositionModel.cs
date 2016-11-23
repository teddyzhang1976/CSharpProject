using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortFolio.Model
{
    public class PositionModel
    {
        public int accountID { get; set; }
        public int stockCode { get; set; }
        public int eventID { get; set; } //outside KEY
        public int positionCount { get; set; }
        public Boolean positionDirection { get; set; }
        public Double purchasePrice { get; set; }
        public DateTime purchaseDate { get; set; } //开仓日期
        public DateTime liquidationDate { get; set; }    //平仓日期
        public String memo { get; set; }
//serialize above properties for storage manage use

        private StockModel stock; //this position belong to stock
        public PositionModel()
        {
            //for loading use
        }
        public PositionModel(StockModel stock):this()
        {
            this.stock = stock;
        }

//below operations are calculated and for view layer component use.
    }
}
