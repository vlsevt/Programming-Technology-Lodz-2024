using WarehouseDataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer.API
{
    public interface IStateCRUD
    {
        static IStateCRUD CreateStateCRUD(IDataRepository? dataRepository = null)
        {
            return new StateCRUD(dataRepository ?? IDataRepository.CreateDatabase());
        }

        void AddState(int StateID, int ProductID, int Quantity);
        IStateDTO GetState(int StateID);
        Dictionary<int, IStateDTO> GetStates();
        void UpdateState(int StateID, int ProductID, int Quantity);
        void DeleteState(int StateID);
    }
}
