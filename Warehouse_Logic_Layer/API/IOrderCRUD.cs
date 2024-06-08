using WarehouseDataLayer.APIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer.API
{
    public interface IOrderCRUD
    {
        static IOrderCRUD CreateOrderCRUD(IDataRepository? dataRepository = null)
        {
            return new OrderCRUD(dataRepository ?? IDataRepository.CreateDatabase());
        }

        void AddOrder(int OrderID, int UserID, int StateID, int Quantity = 0);
        IOrderDTO GetOrder(int OrderID);
        Dictionary<int, IOrderDTO> GetOrders();
        void UpdateOrder(int OrderID, int UserID, int StateID, DateTime Date, int? Quantity);
        void DeleteOrder(int OrderID);
    }
}
