using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseDataLayer.APIs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WarehouseDataTest
{
    [TestClass]
    [DeploymentItem("WarehouseDB.mdf")]
    public class DataTests
    {
        private static string connectionString;

        private readonly IDataRepository _dataRepository = IDataRepository.CreateDatabase(IDataContext.CreateContext(connectionString));

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            string _DBRelativePath = @"WarehouseDB.mdf";
            string _projectRootDir = Environment.CurrentDirectory;
            string _DBPath = Path.Combine(_projectRootDir, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"Database file does not exist at: {_databaseFile}");
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
        }

        [TestMethod]
        public void UserTests()
        {
            int UserID = 1;

            _dataRepository.AddUser(UserID, "John", "Wrublevski");

            IUser User = _dataRepository.GetUser(UserID);

            Assert.IsNotNull(User);
            Assert.AreEqual(UserID, User.ID);
            Assert.AreEqual("John", User.Name);
            Assert.AreEqual("Wrublevski", User.Surname);

            Assert.IsNotNull(_dataRepository.GetUsers());

            Assert.ThrowsException<Exception>(() => _dataRepository.GetUser(UserID + 2));

            _dataRepository.UpdateUser(UserID, "Marisa", "Bunner");

            IUser UserUpdated = _dataRepository.GetUser(UserID);

            Assert.IsNotNull(UserUpdated);
            Assert.AreEqual(UserID, UserUpdated.ID);
            Assert.AreEqual("Marisa", UserUpdated.Name);
            Assert.AreEqual("Bunner", UserUpdated.Surname);

            Assert.ThrowsException<Exception>(() => _dataRepository.UpdateUser(UserID + 2,
                "Marisa", "Bunner"));

            _dataRepository.DeleteUser(UserID);
            Assert.ThrowsException<Exception>(() => _dataRepository.GetUser(UserID));
            Assert.ThrowsException<Exception>(() => _dataRepository.DeleteUser(UserID));
        }

        [TestMethod]
        public void ProductTests()
        {
            int ProductID = 2;

            _dataRepository.AddProduct(ProductID, "Cleaning kit", "Cecil Martin", "Nice thing");

            IProduct Product = _dataRepository.GetProduct(ProductID);

            Assert.IsNotNull(Product);
            Assert.AreEqual(ProductID, Product.ID);
            Assert.AreEqual("Cleaning kit", Product.Name);
            Assert.AreEqual("Cecil Martin", Product.Producer);
            Assert.AreEqual("Nice thing", Product.Description);

            Assert.IsNotNull(_dataRepository.GetProducts());

            Assert.ThrowsException<Exception>(() => _dataRepository.GetProduct(12));

            _dataRepository.UpdateProduct(ProductID, "Wild rug", "Aditya", "Nice thing");

            IProduct ProductUpdated = _dataRepository.GetProduct(ProductID);

            Assert.IsNotNull(ProductUpdated);
            Assert.AreEqual(ProductID, ProductUpdated.ID);
            Assert.AreEqual("Wild rug", ProductUpdated.Name);
            Assert.AreEqual("Aditya", ProductUpdated.Producer);
            Assert.AreEqual("Nice thing", Product.Description);


            Assert.ThrowsException<Exception>(() => _dataRepository.UpdateProduct(12, "Wild rug", "Aditya", "Nice thing"));

            _dataRepository.DeleteProduct(ProductID);
            Assert.ThrowsException<Exception>(() => _dataRepository.GetProduct(ProductID));
            Assert.ThrowsException<Exception>(() => _dataRepository.DeleteProduct(ProductID));
        }

        [TestMethod]
        public void StateTests()
        {
            int ProductID = 3;
            int StateID = 3;

            _dataRepository.AddProduct(ProductID, "Programming in C", "Stephen G. Kochan", "Nice thing");

            IProduct Product = _dataRepository.GetProduct(ProductID);

            _dataRepository.AddState(StateID, ProductID, 20);

            IState State = _dataRepository.GetState(StateID);

            Assert.IsNotNull(State);
            Assert.AreEqual(StateID, State.ID);
            Assert.AreEqual(ProductID, State.ProductID);
            Assert.AreEqual(20, State.Quantity);

            Assert.IsNotNull(_dataRepository.GetStates());

            Assert.ThrowsException<Exception>(() => _dataRepository.GetState(StateID + 2));

            Assert.ThrowsException<Exception>(() => _dataRepository.AddState(StateID, 13, 20));

            Assert.ThrowsException<Exception>(() => _dataRepository.AddState(StateID, ProductID, -1));

            _dataRepository.UpdateState(StateID, ProductID, 5);

            IState StateUpdated = _dataRepository.GetState(StateID);

            Assert.IsNotNull(StateUpdated);
            Assert.AreEqual(StateID, StateUpdated.ID);
            Assert.AreEqual(ProductID, StateUpdated.ProductID);
            Assert.AreEqual(5, StateUpdated.Quantity);

            Assert.ThrowsException<Exception>(() => _dataRepository.UpdateState(StateID + 2, ProductID, 20));
            Assert.ThrowsException<Exception>(() => _dataRepository.UpdateState(StateID, 13, 20));
            Assert.ThrowsException<Exception>(() => _dataRepository.UpdateState(StateID, ProductID, -12));

            _dataRepository.DeleteState(StateID);
            Assert.ThrowsException<Exception>(() => _dataRepository.GetState(StateID));
            Assert.ThrowsException<Exception>(() => _dataRepository.DeleteState(StateID));

            _dataRepository.DeleteProduct(ProductID);
        }

        [TestMethod]
        public void OrderTests()
        {
            int OrderID = 4;
            int UserID = 4;
            int ProductID = 4;
            int StateID = 4;

            _dataRepository.AddProduct(ProductID, "Programming in C", "Stephen G. Kochan", "Nice thing");
            _dataRepository.AddState(StateID, ProductID, 20);
            _dataRepository.AddUser(UserID, "John", "Wick");

            IProduct Product = _dataRepository.GetProduct(ProductID);
            IState State = _dataRepository.GetState(StateID);
            IUser User = _dataRepository.GetUser(UserID);

            _dataRepository.AddOrder(OrderID, UserID, StateID);

            IOrder Order = _dataRepository.GetOrder(OrderID);

            Assert.IsNotNull(Order);
            Assert.AreEqual(OrderID, Order.ID);
            Assert.AreEqual(StateID, Order.StateID);
            Assert.AreEqual(UserID, Order.UserID);

            Assert.IsNotNull(_dataRepository.GetOrders());

            _dataRepository.UpdateOrder(OrderID, UserID, StateID, DateTime.Now, null);

            IOrder OrderUpdated = _dataRepository.GetOrder(OrderID);

            Assert.IsNotNull(OrderUpdated);
            Assert.AreEqual(OrderID, OrderUpdated.ID);
            Assert.AreEqual(StateID, OrderUpdated.StateID);
            Assert.AreEqual(UserID, OrderUpdated.UserID);

            _dataRepository.DeleteOrder(OrderID);
            _dataRepository.DeleteState(StateID);
            _dataRepository.DeleteProduct(ProductID);
            _dataRepository.DeleteUser(UserID);
        }
    }
}
