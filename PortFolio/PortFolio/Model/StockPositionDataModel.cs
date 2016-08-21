using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortFolio.Model
{
    class StockPositionDataModel
    {

        private StockModel stock; //this position belong to stock
        public int positionCount { get; set; }
        public Boolean positionDirection { get; set; }
        public Double purchasePrice { get; set; }
        public DateTime purchaseDate { get; set; } //开仓日期
        public DateTime liquidationDate { get; set; }    //平仓日期
        public String memo { get; set; }

        public StockPositionDataModel(StockModel stock)
        {
            this.stock = stock;
        }
    }
}
