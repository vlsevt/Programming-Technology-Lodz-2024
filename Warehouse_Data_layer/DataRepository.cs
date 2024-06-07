using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WarehouseDataLayer.APIs;
using WarehouseDataLayer.Database;
using Microsoft.Extensions.Logging;
using WarehouseDataLayer;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WarehouseData
{
    internal class DataRepository : IDataRepository
    {
        private IDataContext _context;

        public DataRepository(IDataContext context)
        {
            this._context = context;
        }


        public void AddUser(int UserID, string name, string surname)
        {
            IUser user = new User(UserID, name, surname);
            _context.AddUser(user);
        }

        public IUser GetUser(int UserID)
        {
            IUser? user = this._context.GetUser(UserID);

            if (user is null)
                throw new Exception("User doesn't exist");

            return user;
        }

        public Dictionary<int, IUser> GetUsers()
        {
            return _context.GetUsers();
        }

        public void UpdateUser(int UserID, string name, string surname)
        {

            IUser user = new User(UserID, name, surname);

            if (this.GetUser(UserID) == null)
                throw new ArgumentNullException("User doesn't exist");

            this._context.UpdateUser(user);
        }

        public void DeleteUser(int UserID)
        {
            if (this.GetUser(UserID) == null)
                throw new ArgumentNullException(nameof(User));

            this._context.DeleteUser(UserID);
        }

        



        public void AddProduct(int ProductID, string Name, string Producer, string Description)
        {
            IProduct Product = new Product(ProductID, Name, Producer, Description);
            _context.AddProduct(Product);
        }

        public IProduct GetProduct(int ProductID)
        {
            IProduct? Product = this._context.GetProduct(ProductID);

            if (Product is null)
                throw new Exception("Product doesn't exist");

            return Product;
        }

        public Dictionary<int, IProduct> GetProducts()
        {
            return _context.GetProducts();
        }

        public void UpdateProduct(int ProductID, string Name, string Producer, string Description)
        {
            IProduct Product = new Product(ProductID, Name, Producer, Description);

            if (this.GetProduct(ProductID) == null)
                throw new ArgumentNullException("Product doesn't exist");

            this._context.UpdateProduct(Product);
        }

        public void DeleteProduct(int ProductID)
        {
            if (this.GetProduct(ProductID) == null)
                throw new ArgumentNullException(nameof(Product));

            this._context.DeleteProduct(ProductID);
        }

        



        public void AddState(int StateID, int ProductID, int Quantity)
        {
            if (this.GetProduct(ProductID) == null)
                throw new Exception("Product doesn't exist");

            if (Quantity <= 0)
                throw new Exception("Products quantity must be graete than 0");

            IState state = new State(StateID, ProductID, Quantity);
            _context.AddState(state);
        }

        public IState GetState(int StateID)
        {
            IState? state = this._context.GetState(StateID);

            if (state is null)
                throw new Exception("State doesn't exist");

            return state;
        }

        public Dictionary<int, IState> GetStates()
        {
            return _context.GetStates();
        }

        public void UpdateState(int StateID, int ProductID, int Quantity)
        {
            if (this.GetProduct(ProductID) == null)
                throw new Exception("Product doesn't exist");

            if (Quantity <= 0)
                throw new Exception("Products quantity must be graete than 0");

            IState state = new State(StateID, ProductID, Quantity);

            if (this.GetState(StateID) == null)
                throw new ArgumentNullException("State doesn't exist");

            this._context.UpdateState(state);
        }

        public void DeleteState(int StateID)
        {
            if (this.GetState(StateID) == null)
                throw new ArgumentNullException("State doesn't exist");

            this._context.DeleteState(StateID);
        }

        


        public void AddOrder(int OrderId, int UserID, int StateID, int Quantity = 0)
        {
            IUser user = this.GetUser(UserID);
            IState state = this.GetState(StateID);
            IProduct Product = this.GetProduct(state.ProductID);

            IOrder Order = new Order(OrderId, UserID, StateID, DateTime.Now, Quantity);
            _context.AddOrder(Order);
        }

        public IOrder GetOrder(int OrderId)
        {
            IOrder? Order = this._context.GetOrder(OrderId);

            if (Order is null)
                throw new Exception("Order doesn't exist");

            return Order;
        }

        public Dictionary<int, IOrder> GetOrders()
        {
            return _context.GetOrders();
        }

        public void UpdateOrder(int OrderId, int UserID, int StateID, DateTime Date, int? Quantity)
        {
            IOrder Order = new Order(OrderId, UserID, StateID, Date, Quantity);

            if (this.GetOrder(OrderId) == null)
                throw new ArgumentNullException("Order doesn't exist");

            this._context.UpdateOrder(Order);
        }

        public void DeleteOrder(int OrderId)
        {
            if (this.GetOrder(OrderId) == null)
                throw new ArgumentNullException("Order doesn't exist");

            this._context.DeleteOrder(OrderId);
        }

        
    }
}
