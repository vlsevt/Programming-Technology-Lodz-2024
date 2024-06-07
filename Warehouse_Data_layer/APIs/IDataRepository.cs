using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseDataLayer.APIs;
using WarehouseDataLayer;

namespace LibraryData.API
{
    public interface IDataRepository
    {
        static IDataRepository CreateDatabase(IDataContext? dataContext = null)
        {
            return new DataRepository(dataContext ?? new DataContext());
        }

        void AddUser(int UserID, string Name, string Surname);
        IUser GetUser(int UserID);
        Dictionary<int, IUser> GetUsers();
        void UpdateUser(int UserID, string Name, string Surname);
        void DeleteUser(int UserID);



        void AddProduct(int ProductID, string Name, string Producer, string Description);
        IProduct GetProduct(int ProductID);
        Dictionary<int, IProduct> GetProducts();
        void UpdateProduct(int ProductID, string Name, string Producer, string Description);
        void DeleteProduct(int ProductID);



        void AddState(int StateID, int ProductID, int Quantity);
        IState GetState(int StateID);
        Dictionary<int, IState> GetStates();
        void UpdateState(int StateID, int ProductID, int Quantity);
        void DeleteState(int StateID);


        void AddOrder(int OrderID, int UserID, int StateID, int Quantity = 0);
        IOrder GetOrder(int OrderID);
        Dictionary<int, IOrder> GetOrders();
        void UpdateOrder(int OrderID, int UserID, int StateID, DateTime Date, int? Quantity);
        void DeleteOrder(int OrderID);

    }
}
