using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WarehouseDataLayer;
using WarehouseData;

namespace WarehouseDataLayer.APIs
{
    public interface IDataContext
    {
        static IDataContext CreateContext(string? connectionString = null)
        {
            return new DataContext(connectionString);
        }

        void AddUser(IUser User);
        IUser? GetUser(int UserID);
        Dictionary<int, IUser> GetUsers();
        void UpdateUser(IUser User);
        void DeleteUser(int UserID);


        void AddProduct(IProduct Product);
        IProduct? GetProduct(int ProductID);
        Dictionary<int, IProduct> GetProducts();
        void UpdateProduct(IProduct Product);
        void DeleteProduct(int ProductId);


        void AddState(IState State);
        IState? GetState(int StateID);
        Dictionary<int, IState> GetStates();
        void UpdateState(IState State);
        void DeleteState(int StateID);


        void AddOrder(IOrder Order);
        IOrder? GetOrder(int OrderID);
        Dictionary<int, IOrder> GetOrders();
        void UpdateOrder(IOrder Order);
        void DeleteOrder(int OrderID);
    }
}