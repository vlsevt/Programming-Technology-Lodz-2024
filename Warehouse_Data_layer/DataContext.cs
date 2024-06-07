using WarehouseDataLayer.APIs;
using WarehouseDataLayer.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WarehouseDataLayer;
using System.ComponentModel;

namespace WarehouseData
{
    internal class DataContext : IDataContext
    {
        private readonly string ConnectionString;

        public DataContext(string? connectionString = null)
        {
            if (connectionString is null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            else
            {
                this.ConnectionString = connectionString;
            }
        }


        public void AddUser(IUser User)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                Database.User entity = new Database.User()
                {
                    ID = User.ID,
                    Name = User.Name,
                    Surname = User.Surname,
                };

                context.Users.InsertOnSubmit(entity);
                context.SubmitChanges();
            }
        }

        public IUser? GetUser(int UserID)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                IQueryable<Database.User> query =
                    from u in context.Users
                    where u.ID == UserID
                    select u;

                Database.User? User = query.FirstOrDefault();

                return User is not null ? new User(User.ID, User.Name, User.Surname) : null;
            }
        }

        public Dictionary<int, IUser> GetUsers()
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                IQueryable<IUser> query =
                    from u in context.Users
                    select new User(u.ID, u.Name, u.Surname) as IUser;

                return query.ToDictionary(k => k.ID);
            }
        }

        public void UpdateUser(IUser User)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                Database.User toUpdate = (from u in context.Users where u.ID == User.ID select u).FirstOrDefault()!;

                toUpdate.Name = User.Name;
                toUpdate.Surname = User.Surname;

                context.SubmitChanges();
            }
        }

        public void DeleteUser(int UserID)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                Database.User toDelete = (from u in context.Users where u.ID == UserID select u).FirstOrDefault()!;

                context.Users.DeleteOnSubmit(toDelete);

                context.SubmitChanges();
            }
        }



        public void AddProduct(IProduct Product)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                Database.Product entity = new Database.Product()
                {
                    Id = Product.ID,
                    Name = Product.Name,
                    Producer = Product.Producer,
                    Description = Product.Description,
                };

                context.Products.InsertOnSubmit(entity);
                context.SubmitChanges();
            }
        }

        public IProduct? GetProduct(int ProductID)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                IQueryable<Database.Product> query =
                    from p in context.Products
                    where p.ID == ProductID
                    select p;

                Database.Product? Product = query.FirstOrDefault();

                return Product is not null ? new Product(Product.ID, Product.Producer, Product.Name, Product.Description) : null;
            }
        }

        public Dictionary<int, IProduct> GetProducts()
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                IQueryable<IProduct> query =
                    from p in context.Products
                    select new Product(p.ID, p.Producer, p.Name, p.Description) as IProduct;

                return query.ToDictionary(k => k.ID);
            }
        }

        public void UpdateProduct(IProduct Product)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                Database.Product toUpdate = (from p in context.Products where p.ID == Product.ID select p).FirstOrDefault()!;

                toUpdate.Producer = Product.Producer;
                toUpdate.Name = Product.Name;
                toUpdate.Description = Product.Description;

                context.SubmitChanges();
            }
        }

        public void DeleteProduct(int ProductID)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                Database.Product toDelete = (from p in context.Products where p.ID == ProductID select p).FirstOrDefault()!;

                context.Products.DeleteOnSubmit(toDelete);

                context.SubmitChanges();
            }
        }



        public void AddState(IState State)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                Database.State entity = new Database.State()
                {
                    ID = State.ID,
                    ProductID = State.ProductID,
                    Quantity = State.Quantity,
                };

                context.States.InsertOnSubmit(entity);
                context.SubmitChanges();
            }
        }

        public IState? GetState(int StateID)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                IQueryable<Database.State> query =
                    from s in context.States
                    where s.ID == StateID
                    select s;

                Database.State? State = query.FirstOrDefault();

                return State is not null ? new State(State.ID, State.ProductID, State.Quantity) : null;
            }
        }

        public Dictionary<int, IState> GetStates()
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                IQueryable<IState> query =
                    from s in context.States
                    select new State(s.ID, s.ProductID, s.Quantity) as IState;

                return query.ToDictionary(k => k.ID);
            }
        }

        public void UpdateState(IState State)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                Database.State toUpdate = (from s in context.States where s.ID == State.ID select s).FirstOrDefault()!;

                toUpdate.ProductID = State.ProductID;
                toUpdate.Quantity = State.Quantity;

                context.SubmitChanges();
            }
        }

        public void DeleteState(int StateID)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                Database.State toDelete = (from s in context.States where s.ID == StateID select s).FirstOrDefault()!;

                context.States.DeleteOnSubmit(toDelete);

                context.SubmitChanges();
            }
        }




        public void AddOrder(IOrder Order)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                Database.Order entity = new Database.Order()
                {
                    ID = Order.ID,
                    UserID = Order.UserID,
                    StateID = Order.StateID,
                    Date = Order.Date,
                    Quantity = Order.Quantity,
                };

                context.Orders.InsertOnSubmit(entity);
                context.SubmitChanges();
            }
        }

        public IOrder? GetOrder(int OrderID)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                IQueryable<Database.Order> query =
                    from p in context.Orders
                    where p.ID == OrderID
                    select p;

                Database.Order? Order = query.FirstOrDefault();

                return Order is not null ? new Order(Order.ID, Order.UserID, Order.StateID, Order.Date, Order.Quantity) : null;
            }
        }

        public Dictionary<int, IOrder> GetOrders()
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                IQueryable<IOrder> query =
                    from p in context.Orders
                    select new Order(p.Id, p.UserID, p.StateID, p.Date, p.Quantity) as IOrder;

                return query.ToDictionary(k => k.ID);
            }
        }

        public void UpdateOrder(IOrder Order)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                Database.Order toUpdate = (from p in context.Orders where p.ID == Order.ID select p).FirstOrDefault()!;

                toUpdate.UserID = Order.UserID;
                toUpdate.StateID = Order.StateID;
                toUpdate.Date = Order.Date;
                toUpdate.Quantity = Order.Quantity;

                context.SubmitChanges();
            }
        }

        public void DeleteOrder(int OrderID)
        {
            using (WarehouseDataContext context = new WarehouseDataContext(this.ConnectionString))
            {
                Database.Order toDelete = (from p in context.Orders where p.ID == OrderID select p).FirstOrDefault()!;

                context.Orders.DeleteOnSubmit(toDelete);

                context.SubmitChanges();
            }
        }
    }
}
