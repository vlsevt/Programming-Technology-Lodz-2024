using WarehouseDataLayer.APIs;
using WarehouseLogicLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer
{
    internal class OrderCRUD : IOrderCRUD
    {
        private IDataRepository _dataRepository;

        public OrderCRUD(IDataRepository dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        private IOrderDTO Map(IOrder Order)
        {
            return new OrderDTO(Order.ID, Order.UserID, Order.StateID, Order.Date, Order.Quantity);
        }

        public void AddOrder(int OrderID, int UserID, int StateID, int Quantity = 0)
        {
            this._dataRepository.AddOrder(OrderID, UserID, StateID, Quantity);
        }

        public IOrderDTO GetOrder(int OrderID)
        {
            return this.Map(this._dataRepository.GetOrder(OrderID));
        }

        public Dictionary<int, IOrderDTO> GetOrders()
        {
            Dictionary<int, IOrderDTO> Orders = new Dictionary<int, IOrderDTO>();

            foreach (IOrder Order in (this._dataRepository.GetOrders()).Values)
            {
                Orders.Add(Order.ID, this.Map(Order));
            }

            return Orders;
        }

        public void UpdateOrder(int OrderID, int UserID, int StateID, DateTime Date, int? Quantity)
        {
            this._dataRepository.UpdateOrder(OrderID, UserID, StateID, Date, Quantity);
        }

        public void DeleteOrder(int OrderID)
        {
            this._dataRepository.DeleteOrder(OrderID);
        }
    }
}
