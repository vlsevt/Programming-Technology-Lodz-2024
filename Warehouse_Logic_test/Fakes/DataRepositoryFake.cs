using System;
using System.Collections.Generic;
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
            if (this.Users.TryGetValue(UserID, out var user))
            {
                return user;
            }
            throw new KeyNotFoundException($"The given key '{UserID}' was not present in the dictionary.");
        }

        public Dictionary<int, IUser> GetUsers()
        {
            return this.Users;
        }

        public void UpdateUser(int UserID, string Name, string Surname)
        {
            if (this.Users.ContainsKey(UserID))
            {
                this.Users[UserID].Name = Name;
                this.Users[UserID].Surname = Surname;
            }
            else
            {
                throw new KeyNotFoundException($"The given key '{UserID}' was not present in the dictionary.");
            }
        }

        public void DeleteUser(int UserID)
        {
            this.Users.Remove(UserID);
        }

        public void AddProduct(int ProductID, string Name, string Producer, string Description)
        {
            this.Products.Add(ProductID, new ProductFake(ProductID, Name, Producer, Description));
        }

        public IProduct GetProduct(int ProductID)
        {
            if (this.Products.TryGetValue(ProductID, out var product))
            {
                return product;
            }
            throw new KeyNotFoundException($"The given key '{ProductID}' was not present in the dictionary.");
        }

        public Dictionary<int, IProduct> GetProducts()
        {
            return this.Products;
        }

        public void UpdateProduct(int ProductID, string Name, string Producer, string Description)
        {
            if (this.Products.ContainsKey(ProductID))
            {
                this.Products[ProductID].Name = Name;
                this.Products[ProductID].Producer = Producer;
                this.Products[ProductID].Description = Description;
            }
            else
            {
                throw new KeyNotFoundException($"The given key '{ProductID}' was not present in the dictionary.");
            }
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
            if (this.States.TryGetValue(StateID, out var state))
            {
                return state;
            }
            throw new KeyNotFoundException($"The given key '{StateID}' was not present in the dictionary.");
        }

        public Dictionary<int, IState> GetStates()
        {
            return this.States;
        }

        public void UpdateState(int StateID, int ProductID, int Quantity)
        {
            if (this.States.ContainsKey(StateID))
            {
                this.States[StateID].ProductID = ProductID;
                this.States[StateID].Quantity = Quantity;
            }
            else
            {
                throw new KeyNotFoundException($"The given key '{StateID}' was not present in the dictionary.");
            }
        }

        public void DeleteState(int StateID)
        {
            this.States.Remove(StateID);
        }

        public void AddOrder(int OrderID, int UserID, int StateID, int Quantity = 0)
        {
            IUser user = this.GetUser(UserID);
            IState state = this.GetState(StateID);
            IProduct product = this.GetProduct(state.ProductID);

            this.Orders.Add(OrderID, new OrderFake(OrderID, UserID, StateID, DateTime.Now, Quantity));
        }

        public IOrder GetOrder(int OrderID)
        {
            if (this.Orders.TryGetValue(OrderID, out var order))
            {
                return order;
            }
            throw new KeyNotFoundException($"The given key '{OrderID}' was not present in the dictionary.");
        }

        public Dictionary<int, IOrder> GetOrders()
        {
            return this.Orders;
        }

        public void UpdateOrder(int OrderID, int UserID, int StateID, DateTime Date, int? Quantity)
        {
            if (this.Orders.ContainsKey(OrderID))
            {
                ((OrderFake)this.Orders[OrderID]).UserID = UserID;
                ((OrderFake)this.Orders[OrderID]).StateID = StateID;
                ((OrderFake)this.Orders[OrderID]).Date = Date;
                ((OrderFake)this.Orders[OrderID]).Quantity = Quantity ?? ((OrderFake)this.Orders[OrderID]).Quantity;
            }
            else
            {
                throw new KeyNotFoundException($"The given key '{OrderID}' was not present in the dictionary.");
            }
        }

        public void DeleteOrder(int OrderID)
        {
            this.Orders.Remove(OrderID);
        }
    }
}
