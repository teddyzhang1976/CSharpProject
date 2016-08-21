using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortFolio.Model
{
    class Account
    {
        public String accountName { get; set; }
        public TradingConfig tradingConfig;
        private List<StockModel> stockList; // 交易中或交易过的股票集合
    }
}
