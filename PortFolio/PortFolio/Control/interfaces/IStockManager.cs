using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortFolio.Model;
namespace PortFolio.Control.interfaces
{
    public interface IStockManager
    {
        List<StockModel> load(String accountName);
        Boolean add(StockModel sm);
        Boolean update(StockModel sm);
        StockModel chose(int stockCode);
        Boolean delete(int stockCode);
    }
}
