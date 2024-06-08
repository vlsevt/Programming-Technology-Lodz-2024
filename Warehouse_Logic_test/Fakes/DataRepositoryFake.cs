using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseDataLayer.APIs;
using WarehouseLogicLayer.Fakes;

namespace WarehouseLogicLayer.Fake
{
    internal class DataRepositoryFake : IDataRepository
    {
        public Dictionary<int, IUser> Users = new Dictionary<int, IUser>();

        public Dictionary<int, IProduct> Products = new Dictionary<int, IProduct>();

        public Dictionary<int, IOrder> Orders = new Dictionary<int, IOrder>();

        public Dictionary<int, IState> States = new Dictionary<int, IState>();


        public void AddUser(int UserID, string Name, string Surname)
        {
            this.Users.Add(UserID, new UserFake(UserID, Name, Surname));
        }

        public IUser GetUser(int UserID)
        {
            return this.Users[UserID];
        }

        public Dictionary<int, IUser> GetUsers()
        {
            return this.Users;
        }

        public void UpdateUser(int UserID, string Name, string Surname)
        {
            this.Users[UserID].Name = Name;
            this.Users[UserID].Surname = Surname;
        }

        public void DeleteUser(int UserID)
        {
            this.Users.Remove(UserID);
        }



        #region Product CRUD

        public void AddProduct(int ProductID, string Name, string Producer, string Description)
        {
            this.Products.Add(ProductID, new ProductFake(ProductID, Name, Producer, Description));
        }

        public IProduct GetProduct(int ProductID)
        {
            return this.Products[ProductID];
        }

        public Dictionary<int, IProduct> GetProducts()
        {
            return this.Products;
        }

        public void UpdateProduct(int ProductID, string Name, string Producer, string Description)
        {            
            this.Products[ProductID].Name = Name;
            this.Products[ProductID].Producer = Producer;
            this.Products[ProductID].Description = Description;

        }

        public void DeleteProduct(int ProductID)
        {
            this.Products.Remove(ProductID);
        }


        public void AddState(int StateID, int ProductID, int Quantity)
        {
            this.States.Add(StateID, new StateFake(StateID, ProductID, Quantity));
        }

        public IState GetState(int StateID)
        {
            return this.States[StateID];
        }

        public Dictionary<int, IState> GetStates()
        {
            return this.States;
        }

        public void UpdateState(int StateID, int ProductID, int Quantity)
        {
            this.States[StateID].ProductID = ProductID;
            this.States[StateID].Quantity = Quantity;
        }

        public void DeleteState(int StateID)
        {
            this.States.Remove(StateID);
        }



        public void AddOrder(int OrderID, int UserID, int StateID, int Quantity = 0)
        {
            IUser User = this.GetUser(UserID);
            IState state = this.GetState(StateID);
            IProduct Product = this.GetProduct(state.ProductID);

            this.Orders.Add(OrderID, new OrderFake(OrderID, UserID, StateID, DateTime.Now, Quantity));
        }

        public IOrder GetOrder(int OrderID)
        {
            return this.Orders[OrderID];
        }

        public Dictionary<int, IOrder> GetOrders()
        {
            return this.Orders;
        }

        public void UpdateOrder(int OrderID, int UserID, int StateID, DateTime Date, int? Quantity)
        {
            ((OrderFake)this.Orders[OrderID]).UserID = UserID;
            ((OrderFake)this.Orders[OrderID]).StateID = StateID;
            ((OrderFake)this.Orders[OrderID]).Date = Date;
            ((OrderFake)this.Orders[OrderID]).Quantity = Quantity ?? ((OrderFake)this.Orders[OrderID]).Quantity;
        }

        public void DeleteOrder(int OrderID)
        {
            this.Orders.Remove(OrderID);
        }

    }
}
