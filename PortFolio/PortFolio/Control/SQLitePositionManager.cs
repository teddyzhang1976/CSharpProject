using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortFolio.Control.interfaces;
using PortFolio.Model;
namespace PortFolio.Control
{
   public class SQLitePositionManager:IPositionManager
    {
        private static SQLitePositionManager instance;
        private SQLitePositionManager()
        {
            // singleton
        }

        public static SQLitePositionManager singleInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLitePositionManager();
                }
                return instance;
            }
        }

        public List<List<PositionModel>> load(StockModel sm)
        {
            Console.WriteLine("SQLLitePositionManager.PositionModel");
            List<List<PositionModel>> retList = new List<List<PositionModel>>();
            //load from sql lite according to stockCode and accountID
            //retList[0] is for floating position
            //retList[1] is for liquidation position
            return retList;
        }
       public Boolean add(PositionModel sm)
        {
            //find if there is an sm in db if there is one update it.
            //else store am back to db
            return true;
        }
       public Boolean update(PositionModel sm)
        {
            //find cursor accroding to am's id
            //update it to db
            return true;
        }
       public PositionModel chose(int positionID)
        {
            PositionModel sm = new PositionModel(); //using defaut constructor
            //select model data according to stockCode from db
            //fill with data in sm
            return sm;
        }
       public Boolean delete(int positionID)
        {
            //find the cusor according to stockCode
            //delete it in db
            return true;
        }
    }
}
