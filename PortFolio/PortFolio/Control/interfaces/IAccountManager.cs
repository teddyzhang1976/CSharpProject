using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortFolio.Model;

namespace PortFolio.Control.interfaces
{
    public interface IAccountManager
    {
        List<AccountModel> load();
        Boolean add(AccountModel am);
        Boolean update(AccountModel am);
        AccountModel chose(String accountName);
        Boolean delete(String accountName);
    }
}
