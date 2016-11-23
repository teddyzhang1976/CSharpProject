using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortFolio.Control.interfaces;
using PortFolio.Model;
namespace PortFolio.Control
{
    //This class is only concerned about one table -- Account, which include trading parameters such as 
    public class SQLiteAccountManager:IAccountManager 
    {
        private static SQLiteAccountManager instance;
         private SQLiteAccountManager()
        {
            // singleton
        }

         public static SQLiteAccountManager singleInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLiteAccountManager();
                }
                return instance;
            }
        }

        public List<AccountModel> load()
        {
            Console.WriteLine("SQLLiteAccountManager.loadAccount");
            List<AccountModel> retList = new List<AccountModel>();
            //load from sql lite
            return retList;
        }

        public Boolean add(AccountModel am)
        {
            //find if there is an am in db if there is one update it.
            //else store am back to db
            return true;
        }
        public Boolean update(AccountModel am)
        {
            //find cursor accroding to am's id
            //update it to db
            return true;
        }
        public AccountModel chose(String accountName)
        {
            AccountModel am = new AccountModel();
            //select model data according to accoutID from db
            //fill with data in am
            return am;
        }
        public Boolean delete(String accountName)
        {
            //find the cusor according to accountID
            //delete it in db
            return true;
        }
        
    }
}
