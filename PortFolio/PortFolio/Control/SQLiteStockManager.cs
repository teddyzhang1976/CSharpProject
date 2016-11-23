using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortFolio.Control.interfaces;
using PortFolio.Model;
namespace PortFolio.Control
{
    /// <summary>
    /// work as a whole on StockModel. But StockModel itself is used to calculate something itself.
    /// </summary>
    public class SQLiteStockManager : IStockManager
    {
        private static SQLiteStockManager instance;
        private SQLiteStockManager()
        {
            // singleton
        }

        public static SQLiteStockManager singleInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLiteStockManager();
                }
                return instance;
            }
        }
       public List<StockModel> load(String accountName)
        {
            Console.WriteLine("SQLLiteStockManager.StockModel");
            List<StockModel> retList = new List<StockModel>();
            //load from sql lite according to accountID
            return retList;
        }
       public Boolean add(StockModel sm)
        {
            //find if there is an sm in db if there is one update it.
            //else store am back to db
            return true;
        }
       public Boolean update(StockModel sm)
        {
            //find cursor accroding to am's id
            //update it to db
            return true;
        }
       public StockModel chose(int stockCode)
        {
            StockModel sm = new StockModel(); //using defaut constructor
            //select model data according to stockCode from db
            //fill with data in sm
            return sm;
        }
       public Boolean delete(int stockCode)
        {
            //find the cusor according to stockCode
            //delete it in db
            return true;
        }
    }
}
