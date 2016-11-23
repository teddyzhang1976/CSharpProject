using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortFolio.Control.interfaces;

namespace PortFolio.Control
{
    class GeneralManagerFactory
    {
        //as the manager will be set many times in many places, they should be sington
        public static IAccountManager createAccountManager(){
            return SQLiteAccountManager.singleInstance;
        }

        public static IStockManager createStockManager()
        {
            return SQLiteStockManager.singleInstance;
        }

        public static IPositionManager createPositionManager()
        {
            return SQLitePositionManager.singleInstance;
        }
         public static IEventManager createEventManager()
        {
            return SQLiteEventManager.singleInstance;
        }
        
    }
}
