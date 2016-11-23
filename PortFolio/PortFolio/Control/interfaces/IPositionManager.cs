using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortFolio.Model;

namespace PortFolio.Control.interfaces
{
    public interface IPositionManager
    {
        List<List<PositionModel>> load(StockModel sm);
        Boolean add(PositionModel sm);
        Boolean update(PositionModel sm);
        PositionModel chose(int positionID);
        Boolean delete(int positionID);
    }
}
