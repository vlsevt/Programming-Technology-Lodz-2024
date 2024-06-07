using WarehouseDataLayer.APIs;
using WarehouseLogicLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer
{
    internal class StateCRUD : IStateCRUD
    {
        private IDataRepository _dataRepository;

        public StateCRUD(IDataRepository dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        private IStateDTO Map(IState State)
        {
            return new StateDTO(State.ID, State.ProductID, State.Quantity);
        }

        public void AddState(int StateId, int ProductID, int Quantity)
        {
            this._dataRepository.AddState(StateId, ProductID, Quantity);
        }

        public IStateDTO GetState(int StateId)
        {
            return this.Map(this._dataRepository.GetState(StateId));
        }

        public Dictionary<int, IStateDTO> GetStates()
        {
            Dictionary<int, IStateDTO> States = new Dictionary<int, IStateDTO>();

            foreach (IState State in (this._dataRepository.GetStates()).Values)
            {
                States.Add(State.ID, this.Map(State));
            }

            return States;
        }

        public void UpdateState(int StateId, int ProductID, int Quantity)
        {
            this._dataRepository.UpdateState(StateId, ProductID, Quantity);
        }

        public void DeleteState(int StateId)
        {
            this._dataRepository.DeleteState(StateId);
        }
    }
}
